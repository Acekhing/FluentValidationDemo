using FluentValidationDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationDemo.DTO
{
    public class CustomerCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
