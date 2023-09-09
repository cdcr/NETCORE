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
        public async Task<Employee> GetEmployeeByWeekPeriodId(int Id)
        {
            var query = $"SELECT E.Id,E.[FirstName],E.[LastName],E.[Adress],E.[Email],E.[PhoneNumber],E.[Title],E.[IsFullTime],E.[InsertedDate],E.[UpdatedDate],E.[HourRate],E.[Active] " +
                $"FROM {DatabaseTables.Employee} AS E " +
                $"INNER JOIN {DatabaseTables.WeekPeriod} AS WP " +
                $"ON E.Id = WP.EmployeeId " +
                $"AND WP.EmployeeId = {Id} ";
            var result = (await ExecuteQuery<Employee>(query)).FirstOrDefault();
            return result;

        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var result = (await ExecuteQuery<Employee>(
                $"SELECT *" +
                $" FROM {DatabaseTables.Employee}" +
                $" WHERE [Id] = {Id}")).FirstOrDefault();
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
                    Choseen = "FirstName";
                    break;
                case "lastName":
                    Choseen = "LastName";
                    break;
                case "Adress":
                    Choseen = "Adress";
                    break;
                case "Profile":
                    Choseen = "Profile";
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
                $" SET [FirstName] = @firstName" +
                $",[LastName] = @lastName " +
                $",[Adress] = @adress " +
                $",[email] = @email " +
                $",[PhoneNumber] = @phoneNumber " +
                $",[WorkingHours] = @workingHours " +
                $",[Profile] = @profile  " +
                $",[IsFullTime] = @isFullTime" +
                $",[InsertedDate] = @insertedDate" +
                $",[UpdatedDate] = @updatedDate" +
                $",[HourRate] = @hourRate" +
                $",[Active] = @active" +
                $" WHERE [Id] = {employee.Id}",
                new
                {
                    @firstName = employee.FirstName,
                    @lastName = employee.LastName,
                    @adress = employee.Adress,
                    @email = employee.Email,
                    @phoneNumber = employee.PhoneNumber,
                    @profile = employee.Profile,
                    @isFullTime = employee.IsFullTime,
                    @insertedDate = employee.InsertedDate,
                    @updatedDate = employee.UpdatedDate,
                    @hourRate = employee.HourRate,
                    @active = employee.Active
                });
        }
        public async Task AddEmployee(Employee employee)
        {
            var query = $"INSERT INTO {DatabaseTables.Employee} " +
                $" ([FirstName]" +
                $",[LastName]" +
                $",[Adress]" +
                $",[email]" +
                $",[PhoneNumber]" +
                $",[Profile]" +
                $",[IsFullTime]" +
                $",[InsertedDate]" +
                $",[UpdatedDate] " +
                $",[HourRate]" +
                $",[Active]) " +
                $" VALUES" +
                $"(@firstName" +
                $",@lastName " +
                $",@adress " +
                $",@email " +
                $",@phoneNumber " +
                $",@profile  " +
                $",@isFullTime" +
                $",@insertedDate" +
                $",@updatedDate" +
                $",@hourRate" +
                $",@active" +
                $")";
            await ExecuteQuery(
                query,
                new
                {
                    @firstName = employee.FirstName,
                    @lastName = employee.LastName,
                    @adress = employee.Adress,
                    @email = employee.Email,
                    @phoneNumber = employee.PhoneNumber,
                    @profile = employee.Profile,
                    @isFullTime = employee.IsFullTime,
                    @insertedDate = employee.InsertedDate,
                    @updatedDate = employee.UpdatedDate,
                    @hourRate = employee.HourRate,
                    @active = employee.Active
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
