namespace InventorySystem.Models
{
    public class TransactionDataResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public required List<Transaction> Transactions { get; set; }
        public int TotalSoldProducts { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalDistinctProducts { get; set; }
    }

    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public required string ProductName { get; set; }
        public required string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
