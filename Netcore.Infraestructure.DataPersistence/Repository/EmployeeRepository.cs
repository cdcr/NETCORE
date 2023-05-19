using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.DataPersistence.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Set<Employee>().ToListAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetByField(string field, string value)
        {
            List<Employee> books;
            if (string.IsNullOrEmpty(value))
                return await GetAllEmployees();

            var search = value.ToLower();
            switch (field.ToLower())
            {
                case "first name":
                    books = await _context.Set<Employee>().Where(x => x.FirstName.ToLower().Contains(search)).ToListAsync();
                    break;
                case "last name":
                    books = await _context.Set<Employee>().Where(x => x.LastName.ToLower().Contains(search)).ToListAsync();
                    break;
                case "adress":
                    books = await _context.Set<Employee>().Where(x => x.Address.ToLower().Contains(search)).ToListAsync();
                    break;
                case "title":
                    books = await _context.Set<Employee>().Where(x => x.Title.ToLower().Contains(search)).ToListAsync();
                    break;
                default:
                    books = new List<Employee>();
                    break;
            }
            return books;
        }
        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
                _context.Set<Employee>().Update(employee);
        }
        public void AddEmployee(Employee employee)
        {
            if (employee != null)
                _context.Set<Employee>().Add(employee);
        }

        public  void RemoveEmployee(int Id)
        {
            var employee = _context.Set<Employee>().Where(x => x.Id == Id).FirstOrDefault();
            if (employee != null)
                _context.Remove(employee);
        }

        
    }
}
