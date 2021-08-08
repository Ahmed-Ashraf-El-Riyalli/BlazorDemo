
namespace AuthDemo2.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Specifications { get; set; }

        // The Product may be has more attributes
    }
}
