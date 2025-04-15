
using Microsoft.Extensions.Options;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Blazor.Day02.Services
{
    public class ProductService : IService<Product>
    {

        List<Product> _products;

        public ProductService() {
            _products = [
                new Product { Id = 1, Name = "Laptop", price = 1200.50, ImageURL = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8", CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", price = 850.00, ImageURL = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9", CategoryId = 1 },
                new Product { Id = 3, Name = "Tablet", price = 450.00, ImageURL = "https://images.unsplash.com/photo-1587829741301-dc798b83add3", CategoryId = 1 },
                new Product { Id = 4, Name = "Smartwatch", price = 199.99, ImageURL = "https://images.unsplash.com/photo-1523275335684-37898b6baf30", CategoryId = 1 },
                new Product { Id = 5, Name = "Bluetooth Speaker", price = 79.99, ImageURL = "/images/bluetoooth.png", CategoryId = 1 },

                new Product { Id = 6, Name = "C# Programming Book", price = 40.00, ImageURL = "https://m.media-amazon.com/images/I/41uPjEenkFL.jpg", CategoryId = 2 },
                new Product { Id = 7, Name = "Blazor WebAssembly Guide", price = 35.00, ImageURL = "/images/blazor.png", CategoryId = 2 },
                new Product { Id = 8, Name = "Clean Code", price = 45.00, ImageURL = "https://m.media-amazon.com/images/I/41xShlnTZTL._SX374_BO1,204,203,200_.jpg", CategoryId = 2 },
                new Product { Id = 9, Name = "Design Patterns Book", price = 55.00, ImageURL = "https://m.media-amazon.com/images/I/81gtKoapHFL.jpg", CategoryId = 2 },
                new Product { Id = 10, Name = "The Pragmatic Programmer", price = 50.00, ImageURL = "https://m.media-amazon.com/images/I/518FqJvR9aL._SX377_BO1,204,203,200_.jpg", CategoryId = 2 }

            ];
        }

        public IEnumerable<Product> FindAll(Func<Product, bool> criteria)
        {
            return _products.Where(criteria);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
