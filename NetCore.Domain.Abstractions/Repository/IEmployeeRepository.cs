
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Constants;

namespace NetCore.Domain.Abstractions.Repository
{
    public  interface IEmployeeRepository 
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetByField(string field, string value);
        Task RemoveEmployee(int Id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> GetEmployeeByWeekPeriodId(int Id);



    }
}
