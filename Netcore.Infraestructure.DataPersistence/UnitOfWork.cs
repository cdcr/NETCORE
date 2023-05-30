using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Infraestructure.DataPersistence.Repository;

namespace NetCore.Infraestructure.DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserContext _context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DbContextOptions<UserContext> options)
        {
            _context = new UserContext(options);
            UserRepository = new UserRepository(_context);
        }


        public IUserRepository UserRepository { get; private set; }
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
