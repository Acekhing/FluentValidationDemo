namespace FluentValidationDemo.Models
{
    public class Food
    {
        public Guid FoodId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string LocalName { get; set; }
        public decimal Price  { get; set; }
        public decimal CancelledPrice { get; set; }
        public bool Available { get; set; }
        public List<string> AddOns { get; set; }
    }
}
