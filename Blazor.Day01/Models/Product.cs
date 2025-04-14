namespace Blazor.Day01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }

        public string ImageURL { get; set; }

        public int CategoryId { get; set; }

    }
}
