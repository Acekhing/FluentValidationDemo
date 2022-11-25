using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationDemo.Models
{
    public class AddOn
    {
        public int Id { get; set; } = new Random().Next();
        public string Name { get; set; }
    }
}
