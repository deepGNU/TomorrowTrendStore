﻿using API.Migrations;
using API.Models;
using API.Models.Enums;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserReviewRepository _reviewRepo;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository userRepository, IUserReviewRepository reviewRepository, ILogger<UsersController> logger)
        {
            _userRepo = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _reviewRepo = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Authorize(Policy = "AdminOrWorker")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userRepo.FindAll()
                                .Include(u => u.Address);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get users: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                var user = _userRepo.FindByCondition(u => u.Id == userId)
                    .Include(u => u.Address)
                    .FirstOrDefault();

                if (user is null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get user: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("search")]
        [Authorize(Policy = "AdminOrWorker")]
        public IActionResult GetUsersBySearch([FromQuery] string query)
        {
            try
            {
                var users = _userRepo.FindByCondition(u =>
                        u.FirstName.Contains(query) ||
                        u.LastName.Contains(query) ||
                        u.Email.Contains(query) ||
                        u.Username.Contains(query))
                    .Include(u => u.Address);

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get users: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("CanReviewProduct/{productId:int}")]
        public IActionResult CanUserLeaveReview(int productId)
        {
            try
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                
                var user = _userRepo.FindByCondition(u => u.Id == userId)
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                    .FirstOrDefault();

                if (user is null)
                {
                    return NotFound("User has been deleted.");
                }

                var hasAlreadyReviewed = _reviewRepo.FindByCondition(r => r.ProductId == productId && r.UserId == userId).Any();

                if (hasAlreadyReviewed)
                {
                    return Ok(false);
                }

                var hasPurchased = user.Orders.Any(o => o.OrderLines.Any(ol => ol.ProductId == productId));

                return Ok(hasPurchased);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to determine user's purchase status for product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        //[HttpPost]
        //public IActionResult CreateUser(User user)
        //{
        //    try
        //    {
        //        if (user is null)
        //        {
        //            return BadRequest();
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        User createdUser = _userRepo.Create(user);

        //        return Created("Users", createdUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Failed to create user: {}", ex);
        //        return StatusCode(500, "Internal server error. Please try again later.");
        //    }
        //}

        [HttpGet("Loggedin")]
        public IActionResult GetLoggedInUser()
        {
            int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            try
            {
                var loggedInUser = _userRepo.FindByCondition(u => u.Id == userId).FirstOrDefault();

                if (loggedInUser is null)
                {
                    return NotFound();
                }

                return Ok(loggedInUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get logged in user: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut("{userId:int}")]
        public IActionResult UpdateUser(int userId, User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userId != user.Id)
                {
                    return BadRequest("ID in URL does not match user's ID.");
                }

                var existingUser = _userRepo.FindByCondition(u => u.Id == userId).FirstOrDefault();

                if (existingUser is null)
                {
                    return NotFound();
                }

                existingUser.Type = user.Type;
                existingUser.Username = user.Username;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.ProfileImageURL = user.ProfileImageURL;

                User updatedUser = _userRepo.Update(existingUser);

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update user: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("{userId:int}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var user = _userRepo.FindByCondition(u => u.Id == userId)
                            .Include(u => u.Orders)
                            .FirstOrDefault();

                if (user is null)
                {
                    return NotFound();
                }

                if (user.Orders.Any())
                {
                    return BadRequest("Cannot delete user with orders.");
                }

                _userRepo.Delete(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete user: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        //[HttpGet("{userId}/Cart")]
        //public IActionResult GetCart(int userId)
        //{
        //    try
        //    {
        //        var user = _userRepo.FindByCondition(u => u.Id == userId)
        //                    .Include(u => u.Orders).FirstOrDefault();

        //        if (user is null)
        //        {
        //            return NotFound();
        //        }

        //        var cart = user.Orders.Where(o => o.Status == Status.Cart.ToString())
        //                    .SingleOrDefault();
        //            //from order in user.Orders
        //            //       where order.Status == Status.Cart.ToString()
        //            //       select order;

        //        return Ok(cart);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Failed to get cart: {}", ex);
        //        return StatusCode(500, "Internal server error. Please try again later.");
        //    }
        //}
    }
}
