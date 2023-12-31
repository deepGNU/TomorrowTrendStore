using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IUserReviewRepository _reviewRepo;
        private readonly IProductRepository _productRepo;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(IUserReviewRepository reviewRepository, IProductRepository productRepository, ILogger<ReviewsController> logger)
        {
            _reviewRepo = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _productRepo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult GetReviews([FromQuery] int? productId, [FromQuery] int? userId)
        {
            try
            {
                Expression<Func<UserReview, bool>> condition;

                if (productId.HasValue && userId.HasValue)
                {
                    condition = r => r.ProductId == productId && r.UserId == userId;
                }
                else if (productId.HasValue)
                {
                    condition = r => r.ProductId == productId;
                }
                else if (userId.HasValue)
                {
                    condition = r => r.UserId == userId;
                }
                else
                {
                    condition = r => true;
                }

                var reviews = _reviewRepo.FindByCondition(condition).Include(r => r.User).ToList();

                //var reviewsReversed = reviews.ToList().Reverse();
                reviews.Reverse();

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get reviews: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] UserReview review)
        {
            try
            {   
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                bool isAdmin = User.IsInRole("Admin");

                if (userId != review.UserId && !isAdmin)
                {
                    return Unauthorized();
                }
            
                if (review is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                bool hasAlreadyReviewed = _reviewRepo
                    .FindByCondition(r => r.UserId == userId && r.ProductId == review.ProductId)
                    .Any();

                if (hasAlreadyReviewed)
                {
                    return StatusCode(409, "Review has already been submitted by this user for this product.");
                }

                var product = _productRepo.FindByCondition(p => p.Id == review.ProductId).FirstOrDefault();

                if (product is null)
                {
                    return NotFound("Product not found.");
                }

                var createdReview = _reviewRepo.Create(review);
                
                UpdateProductRating(product);
                
                return Ok(createdReview);
                //return CreatedAtRoute("ReviewById", new { reviewId = review.Id }, review);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create review: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut("{reviewId:int}")]
        public IActionResult UpdateReview(int reviewId, [FromBody] UserReview review)
        {
            try
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                bool isAdmin = User.IsInRole("Admin");

                if (userId != review.UserId && !isAdmin)
                {
                    return Unauthorized();
                }

                if (review is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var product = _productRepo.FindByCondition(p => p.Id == review.ProductId).First();
                var existingReview = _reviewRepo.FindByCondition(r => r.Id == reviewId).FirstOrDefault();
           
                if (existingReview is null)
                {
                    return NotFound();
                }

                existingReview.Rating = review.Rating;
                existingReview.Comment = review.Comment;

                _reviewRepo.Update(existingReview);

                UpdateProductRating(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update review: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult DeleteReview(int reviewId)
        {
            try
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                bool isAdmin = User.IsInRole("Admin");

                var review = _reviewRepo.FindByCondition(r => r.Id == reviewId).FirstOrDefault();

                if (review is null)
                {
                    return NotFound();
                }

                if (userId != review.UserId && !isAdmin)
                {
                    return Unauthorized();
                }

                var product = _productRepo.FindByCondition(p => p.Id == review.ProductId).First();

                _reviewRepo.Delete(review);

                UpdateProductRating(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete review: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        private void UpdateProductRating(Product product)
        {
            var ratings = _reviewRepo.FindByCondition(r => r.ProductId == product.Id)
                    .Select(r => r.Rating);
            product.AverageRating = ratings.Any() ? (decimal)ratings.Average() : 0M;
            product.NumberOfRatings = ratings.Count();
            _productRepo.Update(product);
        }
    }
}
