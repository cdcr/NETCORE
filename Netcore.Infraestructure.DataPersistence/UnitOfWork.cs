using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Infraestructure.DataPersistence.Repository;

namespace NetCore.Infraestructure.DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeContext _context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DbContextOptions<EmployeeContext> options)
        {
            _context = new EmployeeContext(options);
            EmployeeRepository = new EmployeeRepository(_context);
        }


        public IEmployeeRepository EmployeeRepository { get; private set; }
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
