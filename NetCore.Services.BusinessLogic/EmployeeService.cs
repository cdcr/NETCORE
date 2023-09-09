using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Abstractions;
using NetCore.Domain.Entities.DTO;

namespace NetCore.Services.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            newEmployee.Active = true;
            _employeeRepository.AddEmployee(newEmployee);
        }

        public async Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value)
        {
            return (await _employeeRepository.GetByField(field, value))
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Profile = x.Profile,
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
                });
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return (await _employeeRepository.GetAllEmployees())
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Profile = x.Profile,
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
                });
        }

        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            var result = await _employeeRepository.GetEmployeeById(Id);
            return 
                new EmployeeDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Address,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Profile = result.Profile,
                    IsFullTime = result.IsFullTime,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    HourRate = result.HourRate,
                    Active = result.Active
                };
        }

        private string ValidateDomain(string email) 
        {
            return email.ToLower().Contains("entropyzero.com") ? email : "no email";
        }

        private string ValidateLastName(string lastName)
        {
            return !string.IsNullOrWhiteSpace(lastName) ? lastName : "no lastname";
        }
        private string ValidatePhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : "8002472020";
        }


        public async Task<EmployeeWeekPeriodDTO> GetEmployeeByEmployeeAndWeekPeriod(string weekPeriodId, int employeeId)
        {
            var result = await _employeeRepository.GetEmployeeByEmployeeAndWeekPeriod(weekPeriodId, employeeId);
            if (result == null)
                return new EmployeeWeekPeriodDTO();
            return (
                new EmployeeWeekPeriodDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = ValidateLastName(result.LastName),
                    Address = result.Address,
                    Email = ValidateDomain(result.Email),
                    PhoneNumber = ValidatePhoneNumber(result.PhoneNumber),
                    Profile = result.Profile,
                    IsFullTime = result.IsFullTime,
                    HourRate = result.HourRate,
                    Active = result.Active,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    WorkedHours = result.WorkedHours,
                    Bonus = result.WorkedHours > 40 ? 100 : 0,
                    WeekPayment = (result.HourRate * result.WorkedHours),
                    WeekTotalPayment = (result.WorkedHours > 40 ? 100 : 0) + (result.HourRate * result.WorkedHours)
                });
        }

        public void RemoveEmployee(int employeeId)
        {
            _employeeRepository.RemoveEmployee(employeeId);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _employeeRepository.UpdateEmployee(newEmployee);
        }
    }
}
