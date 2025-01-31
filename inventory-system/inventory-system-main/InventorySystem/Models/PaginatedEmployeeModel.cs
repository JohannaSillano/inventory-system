namespace InventorySystem.Models
{
    public class PaginatedEmployeeModel
    {
        public PaginatedEmployeeModel()
        {
            Employees = new List<Employee>(); // Initialize to an empty list
        }

        public IEnumerable<Employee> Employees { get; set; } // Non-nullable Employees property
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
