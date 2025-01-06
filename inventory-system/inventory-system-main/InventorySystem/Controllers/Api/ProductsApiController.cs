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

        // Get all products (existing)
        public IActionResult GetAllProducts()
        {
            var products = _context.Products
                                    .Where(p => !p.IsDeleted)
                                    .ToList();
            return Ok(products);
        }

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
        }
    }
}
