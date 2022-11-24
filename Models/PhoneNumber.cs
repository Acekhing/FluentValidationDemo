using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationDemo.Models
{
    [Keyless]
    [NotMapped]
    public class PhoneNumber
    {
        public string Number { get; set; }
    }
}
