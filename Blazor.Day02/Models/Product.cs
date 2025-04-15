namespace Blazor.Day02.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }

        public string ImageURL { get; set; }

        public int CategoryId { get; set; }


        public override string ToString()
        {
            return $"Product Id:{Id} ::: Product Name: {Name} :::Product Price: {price}";
        }

    }
}
