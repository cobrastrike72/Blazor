using Lab2.WebAPI.Models;

namespace Lab2.WebAPI.Repositories
{
    public class BaseRep<T> : IBaseRepo<T> where T : class
    {
        ITIContext _itiContext;
        public BaseRep(ITIContext iTIContext)
        {
            _itiContext = iTIContext;
        }
        public T Add(T entity)
        {
            _itiContext.Set<T>().Add(entity);
            return entity;
        }


        public void Delete(T entity)
        {
            _itiContext.Set<T>().Remove(entity);
        }


        public List<T> GetAll()
        {
            return _itiContext.Set<T>().ToList();
        }


        public T GetById(int id)
        {
            return _itiContext.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _itiContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
