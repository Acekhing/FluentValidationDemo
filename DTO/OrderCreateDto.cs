using FluentValidationDemo.Models;

namespace FluentValidationDemo.DTO
{
    public class OrderCreateDto
    {
        public Guid CustomerId { get; set; }
        public Guid FoodId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public List<string> AddOns { get; set; }
    }
}
