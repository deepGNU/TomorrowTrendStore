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
    public class CartsController : Controller
    {
        private readonly IShopOrderRepository _orderRepo;
        private readonly IOrderLineRepository _orderLineRepo;
        private readonly IProductRepository _productRepo;
        private readonly ILogger _logger;

        public CartsController(IShopOrderRepository shopOrderRepository, IOrderLineRepository orderLineRepository, IProductRepository productRepository, ILogger<CartsController> logger)
        {
            _orderRepo = shopOrderRepository ?? throw new ArgumentNullException(nameof(shopOrderRepository));
            _orderLineRepo = orderLineRepository ?? throw new ArgumentNullException(nameof(orderLineRepository));
            _productRepo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("userId={userId:int}")]
        [Authorize(Policy = "AdminOrWorker")]
        public IActionResult GetCart(int userId)
        {
            try
            {
                var cart = _orderRepo.FindByCondition(o => o.UserId == userId && o.Status == Status.Cart.ToString())
                            .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product)
                            .FirstOrDefault();
                
                if (cart is null)
                {
                    return NotFound();
                }

                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get cart: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet]
        public IActionResult GetCartForCustomer()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                var cart = _orderRepo.FindByCondition(o => o.UserId.ToString() == userId && o.Status == Status.Cart.ToString())
                                .Include(o => o.OrderLines)
                                .ThenInclude(ol => ol.Product)
                                .FirstOrDefault();
                
                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get cart: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost("Orderlines")]
        public IActionResult AddItemToCart([FromBody] int productId)
        {
            //int? productId = valuePairs.GetValue("productId")?.ToObject<int>();

            //if (productId is null)
            //{
            //    return BadRequest("Orderline must include product ID.");
            //}

            //int quantity = valuePairs.GetValue("quantity")?.ToObject<int>() ?? 1;
            var product = _productRepo.FindByCondition(p => p.Id == productId).FirstOrDefault();

            if (product is null)
            {
                return NotFound($"No product with ID {productId} was found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _orderRepo.FindByCondition(o => o.UserId.ToString() == userId && o.Status == Status.Cart.ToString())
                        .Include(c => c.OrderLines)
                        .ThenInclude(ol => ol.Product)
                        .FirstOrDefault();

            if (cart is null)
            {
                ShopOrder newCart = new()
                {
                    UserId = Convert.ToInt32(userId),
                    Status = Status.Cart.ToString(),
                };

                cart = _orderRepo.Create(newCart);
            }

            OrderLine newLine = new()
            {
                ProductId = product.Id,
                Quantity = 1,
                ShopOrderId = cart.Id,
                Product = product,
                Price = product.Price
            };

            _orderLineRepo.Create(newLine);

            return Ok(cart);
        }

        [HttpPut("{cartId:int}/Orderlines/{orderLineId:int}")]
        public IActionResult UpdateQuantityInLine(int cartId, int orderLineId, [FromBody] int newQuantity)
        {
            //var orderLine = _orderLineRepo.FindByCondition(ol => ol.Id == orderLineId)
            //                .Include(ol => ol.Product)
            //                .FirstOrDefault();

            var cart = _orderRepo.FindByCondition(o => o.Id == cartId)
                        .Include(o => o.OrderLines)
                        .ThenInclude(ol => ol.Product)
                        .FirstOrDefault();

            if (cart is null || cart.Status != Status.Cart.ToString())
            {
                return NotFound();
            }

            var orderLine = cart.OrderLines.FirstOrDefault(ol => ol.Id == orderLineId);

            if (orderLine is null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole(UserType.Admin.ToString());
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userIdOnOrder = _orderRepo.FindByCondition(o => o.Id == orderLine.ShopOrderId)
            //                        .Select(o => o.UserId)
            //                        .FirstOrDefault();

            if (!isAdmin && userId != cart.UserId.ToString())
            {
                return Unauthorized();
            }

            orderLine.Quantity = newQuantity;
            orderLine.Price = orderLine.Product.Price * newQuantity;

            var updatedOrderLine = _orderLineRepo.Update(orderLine);

            return Ok(updatedOrderLine);
        }

        [HttpDelete("Orderlines/{orderLineId:int}")]
        public IActionResult DeleteLineFromOrder(int orderLineId)
        {
            var orderLine = _orderLineRepo.FindByCondition(ol => ol.Id == orderLineId).FirstOrDefault();

            if (orderLine is null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole(UserType.Admin.ToString());
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIdOnOrder = _orderRepo.FindByCondition(o => o.Id == orderLine.ShopOrderId)
                                    .Select(o => o.UserId)                
                                    .FirstOrDefault();

            if (!isAdmin && userId != userIdOnOrder.ToString())
            {
                return Unauthorized();
            }

            _orderLineRepo.Delete(orderLine);

            return NoContent();
        }

        [HttpPut("{orderId:int}/Checkout")]
        public IActionResult CheckoutCart(int orderId)
        {
            var cart = _orderRepo.FindByCondition(o => o.Id == orderId && o.Status == Status.Cart.ToString())
                        .Include(c => c.OrderLines)
                        .FirstOrDefault();

            if (cart is null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isAdmin = User.IsInRole(UserType.Admin.ToString());

            if (!isAdmin && userId != cart.UserId.ToString())
            {
                return Unauthorized();
            }

            foreach (var orderline in cart.OrderLines)
            {
                Product product = _productRepo.FindByCondition(p => p.Id == orderline.ProductId).First();
                product.Stock -= orderline.Quantity;
                _productRepo.Update(product);
            }

            cart.Status = Status.Pending.ToString();
            cart.OrderDate = DateTime.Now;
            cart.TotalPrice = cart.OrderLines.Sum(ol => ol.Price);

            var newOrder = _orderRepo.Update(cart);

            return Ok(newOrder);
        }
    }
}
