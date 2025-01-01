using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;
using System.Linq;

namespace InventorySystem.Controllers.Api 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint to get all products that are not deleted
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products
                                    .Where(p => !p.IsDeleted)  // Exclude deleted products
                                    .ToList();
            return Ok(products);
        }

        [HttpPost("updateproductstock")]
        public IActionResult UpdateProductStock([FromBody] StockUpdateRequest request)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                return NotFound(new { Error = "Product not found." });
            }

            product.StockQuantity += request.StockQuantity; // Deduct or add stock

            _context.SaveChanges();

            return Ok(new { Message = "Stock updated successfully!" });
        }
    }
}
