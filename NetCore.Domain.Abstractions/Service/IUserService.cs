using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<IEnumerable<UserDTO>> GeByField(string field, string value);
        void AddUser(UserDTO User);
        void UpdateUser(UserDTO User);
        void RemoveUser(UserDTO User);
    }
}
