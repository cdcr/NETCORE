
using NetCore.Domain.Entities;

namespace NetCore.Domain.Abstractions.Repository
{
    public  interface IUserRepository : IBaseRepository<User> 
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetByField(string field, string value);
        void RemoveUser(int Id);
        void AddUser(User User);
        void UpdateUser(User User);


    }
}
