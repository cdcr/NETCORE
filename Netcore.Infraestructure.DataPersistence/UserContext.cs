using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.DataPersistence
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
