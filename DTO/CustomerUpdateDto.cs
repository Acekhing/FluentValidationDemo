using System.ComponentModel.DataAnnotations;

namespace FluentValidationDemo.DTO
{
    public class CustomerUpdateDto
    {
        [Required]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
