using API.Models;
using API.Models.Enums;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IShopOrderRepository _orderRepo;
        private readonly IOrderLineRepository _orderLineRepo;
        private readonly IUserRepository _userRepo;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IShopOrderRepository shopOrderRepository, IOrderLineRepository orderLineRepository, IUserRepository userRepository, ILogger<OrdersController> logger)
        {
            _orderRepo = shopOrderRepository ?? throw new ArgumentNullException(nameof(shopOrderRepository));
            _orderLineRepo = orderLineRepository ?? throw new ArgumentNullException(nameof(orderLineRepository));
            _userRepo = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Authorize(Policy = "AdminOrWorker")]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = _orderRepo.FindAll()
                            .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product);

                var users = _userRepo.FindAll().Include(u => u.Address);

                var query = from o in orders
                            join u in users on o.UserId equals u.Id
                            select new
                            {
                                o.Id,
                                o.Status,
                                o.TotalPrice,
                                o.OrderDate,
                                o.OrderLines,
                                o.UserId,
                                u.FirstName,
                                u.LastName,
                                u.Email,
                                u.PhoneNumber,
                                u.Address
                            };
                
                return Ok(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get orders: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        
        [HttpGet("{orderId:int}")]
        public IActionResult GetOrder(int orderID)
        {
            try
            {
                var order = _orderRepo.FindByCondition(o => o.Id == orderID)
                            .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product)
                            .FirstOrDefault();
                
                if (order is null)
                {
                    return NotFound();
                }
                
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
               
                bool isAdminOrWorker = User.IsInRole(UserType.Admin.ToString()) || User.IsInRole(UserType.Worker.ToString());

                if (userId != order.UserId && !isAdminOrWorker)
                {
                    return Unauthorized();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get order: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            try
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int loggedInUserId);

                bool isAdminOrWorker = User.IsInRole(UserType.Admin.ToString()) || User.IsInRole(UserType.Worker.ToString());

                if (userId != loggedInUserId && !isAdminOrWorker)
                {
                    return Unauthorized();
                }

                var orders = _orderRepo.FindByCondition(o => o.UserId == userId)
                            .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get orders: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("HasPurchased/{productId:int}")]
        public IActionResult LoggedInUserHasPurchasedProduct(int productId)
        {
            try
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                
                var orders = _orderRepo.FindByCondition(o => o.UserId == userId)
                            .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product);

                var hasPurchased = orders.Any(o => o.OrderLines.Any(ol => ol.ProductId == productId));

                return Ok(hasPurchased);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to determine user's purchase status for product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(ShopOrder newOrder)
        {
            try
            {
                if (newOrder is null)
                {
                    return BadRequest("Order object is null");
                }

                Console.WriteLine(ModelState.IsValid);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                newOrder.OrderDate = DateTime.Now;
                var createdOrder = _orderRepo.Create(newOrder);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create order: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [Authorize(Policy = "AdminOrWorker")]
        [HttpPut("{orderId:int}")]
        public IActionResult UpdateOrder(int orderId, [FromBody]ShopOrder order)
        {
            try
            {
                if (orderId != order.Id)
                {
                    return BadRequest();
                }
                
                var orderFound = _orderRepo.FindByCondition(o => o.Id == orderId).FirstOrDefault();

                if (orderFound is null)
                {
                    return NotFound();
                }

                orderFound.Status = order.Status;
                orderFound.TotalPrice = order.TotalPrice;

                ShopOrder updatedOrder = _orderRepo.Update(orderFound);

                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update order: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("{orderId:int}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var order = _orderRepo.FindByCondition(o => o.Id == orderId).FirstOrDefault();
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                bool isAdmin = User.IsInRole(UserType.Admin.ToString());

                if (order is null)
                {
                    return NotFound();
                }

                if (userId != order?.UserId && !isAdmin)
                {
                    return Unauthorized();
                }

                _orderRepo.Delete(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete order: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
