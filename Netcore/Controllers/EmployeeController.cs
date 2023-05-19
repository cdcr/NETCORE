using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities.DTO;

namespace Netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _emloyeeService;
        public EmployeeController(IEmployeeService emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByField(string field, string value)
        {
            return await _emloyeeService.GeByField(field, value);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            
            return await _emloyeeService.GetAll();
        }

        [HttpPost]
        [Route("Save")]
        public void AddEmployee(EmployeeDTO employee)
        {
             _emloyeeService.AddEmployee(employee);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateEmployee(EmployeeDTO employee)
        {

            _emloyeeService.UpdateEmployee(employee);
        }

        [HttpPost]
        [Route("Delete")]
        public void RemoveEmployee(EmployeeDTO employee)
        {

            _emloyeeService.RemoveEmployee(employee);
        }
    }

        
}
