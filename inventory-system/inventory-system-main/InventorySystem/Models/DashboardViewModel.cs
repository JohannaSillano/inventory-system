using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public required List<Product> TopProductsByQuantity { get; set; }
        public required List<Product> TopProductsByPrice { get; set; }
        public required List<CategoryStock> TopCategoriesByStock { get; set; } 
        public int OutOfStockProducts{ get; set; } 
        public int ProductsAddedToday { get; set; }
        public int ProductsAddedThisWeek { get; set; }
        public int ProductsAddedThisMonth { get; set; }
        public int ProductsAddedThisYear { get; set; }
    }
}
