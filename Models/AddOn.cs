using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationDemo.Models
{
    [Keyless]
    [NotMapped]
    public class AddOn
    {
        public string Name { get; set; }
    }
}
