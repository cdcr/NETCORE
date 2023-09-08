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
            _unitOfWork.Complete();
        }

        public async Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value)
        {
            return (await _unitOfWork.EmployeeRepository.GetByField(field, value))
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Adress,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Title = x.Title,
                    IsFullTime = x.IsFullTime
                });
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return (await _unitOfWork.EmployeeRepository.GetAllEmployees())
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Adress,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Title = x.Title,
                    IsFullTime = x.IsFullTime
                });
        }

        public void RemoveEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.RemoveEmployee(newEmployee.Id);
            _unitOfWork.Complete();
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.UpdateEmployee(newEmployee);
            _unitOfWork.Complete();
        }
    }
}
