using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationDemo.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; } = new Random().Next();
        public string Number { get; set; }
    }
}
