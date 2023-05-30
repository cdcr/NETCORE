using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.DataPersistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Set<User>().ToListAsync();
        }
        
        public async Task<IEnumerable<User>> GetByField(string field, string value)
        {
            List<User> books;
            if (string.IsNullOrEmpty(value))
                return await GetAllUsers();

            var search = value.ToLower();
            switch (field.ToLower())
            {
                case "name":
                    books = await _context.Set<User>().Where(x => x.Name.ToLower().Contains(search)).ToListAsync();
                    break;
                case "status":
                    books = await _context.Set<User>().Where(x => x.Status.ToLower().Contains(search)).ToListAsync();
                    break;
                case "email":
                    books = await _context.Set<User>().Where(x => x.Email.ToLower().Contains(search)).ToListAsync();
                    break;
                case "title":
                    books = await _context.Set<User>().Where(x => x.Title.ToLower().Contains(search)).ToListAsync();
                    break;
                default:
                    books = new List<User>();
                    break;
            }
            return books;
        }
        public void UpdateUser(User User)
        {
            if (User != null)
                _context.Set<User>().Update(User);
        }
        public void AddUser(User User)
        {
            if (User != null)
                _context.Set<User>().Add(User);
        }

        public  void RemoveUser(int Id)
        {
            var User = _context.Set<User>().Where(x => x.Id == Id).FirstOrDefault();
            if (User != null)
                _context.Remove(User);
        }

        
    }
}
