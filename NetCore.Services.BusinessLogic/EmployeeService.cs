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
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Adress,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Title = x.Title,
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
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
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
                });
        }

        public async Task<EmployeeDTO> GetAll(int Id)
        {
            var result = await _unitOfWork.EmployeeRepository.GetEmployeeById(Id);
            return (
                new EmployeeDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Adress,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Title = result.Title,
                    IsFullTime = result.IsFullTime,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    HourRate = result.HourRate,
                    Active = result.Active
                });
        }
        public async Task<EmployeeDTO> GetEmployeeByWeekPeriodId(int Id)
        {
            var result = await _unitOfWork.EmployeeRepository.GetEmployeeByWeekPeriodId(Id);
            return (
                new EmployeeDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Adress,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Title = result.Title,
                    IsFullTime = result.IsFullTime,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    HourRate = result.HourRate,
                    Active = result.Active
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
