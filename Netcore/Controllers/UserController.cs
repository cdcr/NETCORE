using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities.DTO;

namespace Netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _emloyeeService;
        public UserController(IUserService emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IEnumerable<UserDTO>> GetUsersByField(string field, string value)
        {
            return await _emloyeeService.GeByField(field, value);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            
            return await _emloyeeService.GetAll();
        }

        [HttpPost]
        [Route("Save")]
        public void AddUser(UserDTO User)
        {
             _emloyeeService.AddUser(User);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateUser(UserDTO User)
        {

            _emloyeeService.UpdateUser(User);
        }

        [HttpDelete]
        [Route("Delete")]
        public void RemoveUser(UserDTO User)
        {

            _emloyeeService.RemoveUser(User);
        }
    }

        
}
