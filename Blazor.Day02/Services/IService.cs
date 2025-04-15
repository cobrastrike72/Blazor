using System.Linq.Expressions;

namespace Blazor.Day02.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> FindAll(Func<T, bool> criteria); // if i was dealing with sql i will need to surrond that delegate with Expression in order to be able to deal with database
    }
}
