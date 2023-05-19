
using NetCore.Domain.Entities;

namespace NetCore.Domain.Abstractions.Repository
{
    public  interface IEmployeeRepository : IBaseRepository<Employee> 
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetByField(string field, string value);
        void RemoveEmployee(int Id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);


    }
}
