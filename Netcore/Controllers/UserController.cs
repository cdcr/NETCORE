using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities.DTO;

namespace Netcore.Controllers
{
    public class UserController : Controller
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

        [HttpGet]
        [Route("GetUserById")]
        public async Task<UserDTO> GetUserById(int Id)
        {
            return await _emloyeeService.GetUserById(Id);
        }

        [HttpGet]
        [Route("GetUserByWeekPeriodId")]
        public async Task<UserDTO> GetUserByWeekPeriodId(int WeekPeriodId)
        {
            return await _emloyeeService.GetUserByWeekPeriodId(WeekPeriodId);
        }

        [HttpPost]
        public void AddUser(UserDTO employee)
        {
            _emloyeeService.AddUser(employee);
        }

        [HttpPut]
        public void UpdateUser(UserDTO employee)
        {

            _emloyeeService.UpdateUser(employee);
        }

        [HttpDelete]
        public void RemoveUser(UserDTO employee)
        {

            _emloyeeService.RemoveUser(employee);
        }
    }
}
