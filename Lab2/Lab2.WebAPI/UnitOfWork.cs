using Lab2.WebAPI.Models;
using Lab2.WebAPI.Repositories;
using Lab2.WebAPI.Repositories;

namespace Lab2.WebAPI
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITIContext _context;
        private IBaseRepo<Student> _studentRepo;
        private IBaseRepo<Department> _departmentRepo;

        public UnitOfWork(ITIContext context)
        {
            _context = context;
        }

        public IBaseRepo<Student> StudentRepo
        {
            get
            {
                if (_studentRepo == null)
                {
                    _studentRepo = new BaseRep<Student>(_context);
                }
                return _studentRepo;
            }
        }

        public IBaseRepo<Department> DepartmentRepo
        {
            get
            {
                if (_departmentRepo == null)
                {
                    _departmentRepo = new BaseRep<Department>(_context);
                }
                return _departmentRepo;
            }
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
