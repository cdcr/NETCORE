using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Constants;

namespace NetCore.Infraestructure.DataPersistence.Repository
{
    public class EmployeeRepository : DBBase, IEmployeeRepository
    {
        public EmployeeRepository(DapperContext dapperContext) : base(dapperContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var result = (await ExecuteQuery<Employee>(
                $"SELECT *" +
                $"  FROM {DatabaseTables.Employee}")).ToList();
            return result;

        }
        
        public async Task<IEnumerable<Employee>> GetByField(string field, string value)
        {
            string Choseen = "";
            if (string.IsNullOrEmpty(value))
                return await GetAllEmployees();
            switch (field)
            {
                case "firstName":
                    Choseen = "first_name";
                    break;
                case "lastName":
                    Choseen = "last_name";
                    break;
                case "address":
                    Choseen = "address";
                    break;
                case "title":
                    Choseen = "title";
                    break;
                default: 
                    Choseen = "Id";
                    break;
            }
            string query =
                $"SELECT *" +
                $" FROM {DatabaseTables.Employee} " +
                $" WHERE [{Choseen}] LIKE '%{value}%'";
            return (await ExecuteQuery<Employee>(query)).ToList();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await ExecuteQuery(
                $"UPDATE {DatabaseTables.Employee}" +
                $" SET [first_name] = @firstName" +
                $",[last_name] = @lastName " +
                $",[address] = @adress " +
                $",[email] = @email " +
                $",[phone_number] = @phoneNumber " +
                $",[working_hours] = @workingHours " +
                $",[title] = @title  " +
                $",[is_full_time] = @isFullTime" +
                $" WHERE [Id] = {employee.Id}",
                new
                {
                    @firstName = employee.first_name,
                    @lastName = employee.last_name,
                    @adress = employee.address,
                    @email = employee.email,
                    @phoneNumber = employee.phone_number,
                    @workingHours = employee.working_hours,
                    @title = employee.title,
                    @isFullTime = employee.is_full_time
                });
        }
        public async Task AddEmployee(Employee employee)
        {
            await ExecuteQuery(
                $"INSERT {DatabaseTables.Employee} " +
                $" ([first_name]" +
                $" ,[last_name]" +
                $" ,[address]" +
                $" ,[email]" +
                $" ,[phone_number]" +
                $" ,[working_hours]" +
                $" ,[title]" +
                $" ,[is_full_time])" +
                $" VALUES" +
                $"(@firstName" +
                $",@lastName " +
                $",@adress " +
                $",@email " +
                $",@phoneNumber " +
                $",@workingHours " +
                $",@title  " +
                $",@isFullTime)",
                new
                {
                    @firstName = employee.first_name,
                    @lastName = employee.last_name,
                    @adress = employee.address,
                    @email = employee.email,
                    @phoneNumber = employee.phone_number,
                    @workingHours = employee.working_hours,
                    @title = employee.title,
                    @isFullTime = employee.is_full_time
                });
        }

        public async Task RemoveEmployee(int Id)
        {
            await ExecuteQuery(
                $"DELETE FROM {DatabaseTables.Employee}" +
                $"WHERE [Id] = {Id}");
        }
    }
}
