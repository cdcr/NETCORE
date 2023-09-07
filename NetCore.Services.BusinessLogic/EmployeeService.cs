using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;

namespace NetCore.Services.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.AddEmployee(newEmployee);
        }

        public async Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value)
        {
            return (await _unitOfWork.EmployeeRepository.GetByField(field, value))
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.first_name,
                    LastName = x.last_name,
                    Address = x.address,
                    Email = x.email,
                    PhoneNumber = x.phone_number,
                    WorkingHours = x.working_hours,
                    Title = x.title,
                    IsFullTime = x.is_full_time
                });
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return (await _unitOfWork.EmployeeRepository.GetAllEmployees())
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.first_name,
                    LastName = x.last_name,
                    Address = x.address,
                    Email = x.email,
                    PhoneNumber = x.phone_number,
                    WorkingHours = x.working_hours,
                    Title = x.title,
                    IsFullTime = x.is_full_time
                });
        }

        public void RemoveEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.RemoveEmployee(newEmployee.Id);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.UpdateEmployee(newEmployee);
        }
    }
}
