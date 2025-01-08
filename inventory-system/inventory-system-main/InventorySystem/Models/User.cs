using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Auto-incrementing primary key
        public required string FirstName { get; set; } // First name column
        public required string LastName { get; set; } // Last name column
        public required string Email { get; set; } // Email address
        public required string Password { get; set; } // Store hashed passwords
    }
}
