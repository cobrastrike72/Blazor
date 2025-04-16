using System.Collections.Generic;

namespace Lab2.WebAPI.Repositories
{
    public interface IBaseRepo<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        T Update(T entity);
    }
}
