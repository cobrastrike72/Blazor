
using System.Linq.Expressions;

namespace Blazor.Day02.Services
{
    public class CategoryService : IService<Category>
    {
        List<Category> _categories;
        public CategoryService() {
            _categories = [
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }
            ];
        }

        public IEnumerable<Category> FindAll(Func<Category, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

    }
}
