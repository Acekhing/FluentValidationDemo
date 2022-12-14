using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationDemo.Models
{
    public class Customer
    {
        [Required]
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public int Score { get; set; } = 0;
    }
}
