namespace InventorySystem.Models;
public class StockUpdateRequest
{
    public int ProductId { get; set; }
    public int StockQuantity { get; set; } // Positive to add, negative to deduct stock
}
