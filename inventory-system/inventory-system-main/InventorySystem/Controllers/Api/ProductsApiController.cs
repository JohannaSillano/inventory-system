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

<<<<<<< HEAD
        // Endpoint to get all products that are not deleted
        [HttpGet]
=======
        // Get all products (existing)
>>>>>>> origin/main
        public IActionResult GetAllProducts()
        {
            var products = _context.Products
                                    .Where(p => !p.IsDeleted)  // Exclude deleted products
                                    .ToList();
            return Ok(products);
        }
<<<<<<< HEAD
        // Endpoint to get a single product by ID
        [HttpPost]
        public IActionResult UpdateProductStock([FromBody] StockUpdateRequest request)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.ProductId);
            if (product == null)
            {
                return NotFound(new { Error = "Product not found." });
            }

            product.StockQuantity += request.StockQuantity; // Deduct or add stock

            _context.SaveChanges();

            return Ok(new { Message = "Stock updated successfully!" });
=======

        // Search products by name
        [HttpGet]
        public IActionResult SearchProducts(string query)
        {
            // If the search query is empty or null, return all products
            if (string.IsNullOrWhiteSpace(query))
            {
                var allProducts = _context.Products
                                          .Where(p => !p.IsDeleted)
                                          .ToList();
                return Ok(allProducts);
            } else {
                // Otherwise, perform a case-insensitive search for the products
                var matchingProducts = _context.Products
                                            .Where(p => !p.IsDeleted && p.Name.ToLower().Contains(query.ToLower()))
                                            .ToList();

                return Ok(matchingProducts);
            }
>>>>>>> origin/main
        }
    }
}
