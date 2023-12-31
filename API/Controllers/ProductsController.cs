using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _ProductRepo;
        private readonly IUserReviewRepository _reviewRepo;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository, IUserReviewRepository reviewRepository, ILogger<ProductsController> logger)
        {
            _ProductRepo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _reviewRepo = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _ProductRepo.FindAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get products: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("featured")]
        public IActionResult GetFeaturedProducts()
        {
            try
            {
                var products = _ProductRepo.FindByCondition(p => p.IsFeatured);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get products: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = _ProductRepo.FindByCondition(p => p.Id == productId).FirstOrDefault();

                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("results")]
        public IActionResult GetProductsBySearch([FromQuery] string search_query)
        {
            try
            {
                var products = _ProductRepo.FindByCondition(p =>
                    p.Name.Contains(search_query) ||
                    p.ShortDescription.Contains(search_query) ||
                    p.LongDescription.Contains(search_query));
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get products: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("filter")]
        public IActionResult GetProductsByFilter([FromQuery] decimal maxPrice = 99999, [FromQuery] int minRating = 0)
        {
            try
            {
                var products = _ProductRepo.FindByCondition(p => p.Price <= maxPrice);

                if (minRating == 0)
                {
                    return Ok(products);
                }
                
                var reviews = _reviewRepo.FindAll();

                var avgRatings = reviews
                    .GroupBy(r => r.ProductId)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        AverageRating = g.Average(r => r.Rating)
                    })
                    .Where(g => g.AverageRating >= minRating);

                var query = from p in products
                            join r in avgRatings on p.Id equals r.ProductId
                            select p;
                
                return Ok(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get products: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut("{productId:int}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult UpdateProduct(int productId, Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (productId != product.Id)
            {
                return BadRequest("ID in URL does not match product's ID.");
            }
            
            try
            {
                bool productExists = _ProductRepo.FindByCondition(p => p.Id == productId).Any();

                if (!productExists)
                {
                    return NotFound();
                }

                var updatedProduct =  _ProductRepo.Update(product);

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrWorker")]
        public IActionResult CreateProduct(Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                var createdProduct = _ProductRepo.Create(product);

                return CreatedAtAction(nameof(GetProductById), new { productId = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to insert product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("{productId:int}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var product = _ProductRepo.FindByCondition(p => p.Id == productId).FirstOrDefault();

                if (product is null)
                {
                    return NotFound();
                }

                _ProductRepo.Delete(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete product: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
