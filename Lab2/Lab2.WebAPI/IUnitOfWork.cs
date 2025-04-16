using Lab2.WebAPI.Models;
using Lab2.WebAPI.Repositories;
using Lab2.WebAPI.Repositories;

namespace Lab2.WebAPI
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<Department> DepartmentRepo { get; }
        IBaseRepo<Student> StudentRepo { get; }

        int Complete();
    }
}
