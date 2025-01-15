using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class EmployeeProfile
    {
        [Key]
        public int Id { get; set; } // Auto-incrementing primary key
        public required string FirstName { get; set; } // First name column
        public required string LastName { get; set; } // Last name column
        public required string Email { get; set; } // Email column
        public required string PhoneNumber { get; set; } // Phone number column
        public required string Address { get; set; } // Address column
        public required string Role { get; set; } // Role column
    }
}
