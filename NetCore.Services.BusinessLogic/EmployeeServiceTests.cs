using Microsoft.Extensions.Configuration;
using Moq;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities.DTO;
using NetCore.Infraestructure.DataPersistence;
using NetCore.Infraestructure.DataPersistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetCore.Services.BusinessLogic
{
    public class EmployeeServiceTests
    {

        //private EmployeeService _employeeService;
        //private Mock<IEmployeeRepository> _mockEmployeeRepository;

        //public IConfigurationRoot CreateConfig()
        //{            
        //    return
        //        new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //}


        


        

        public EmployeeServiceTests()
        {

            //_mockEmployeeRepository = new Mock<IEmployeeRepository>();
            //_mockEmployeeRepository.Setup(rep => rep.GetEmployeeByEmployeeAndWeekPeriod(It.IsAny<int>(), It.IsAny<int>()))
            //    .ReturnsAsync(
            //    new EmployeeWeekPeriodDTO()
            //    {
            //        Id = 1,
            //        FirstName = "Pedro",
            //        LastName = "Monzon",
            //        Address = "44 E. West Street Ashland, OH 44805",
            //        PhoneNumber = "3216632325",
            //        IsFullTime = true,
            //        Profile = "Admin",
            //        Email = "pmonzon@entropyzero.com",
            //        Active = true,
            //        HourRate = 20,
            //        WorkedHours = 40
            //    });


            ////var _config = CreateConfig();

            ////var dapperContext =
            // //   new DapperContext(_config);

            ////_employeeRepository =
            ////    new EmployeeRepository(dapperContext);

            //_employeeService = new EmployeeService(_mockEmployeeRepository.Object);

        }


        //[Fact]
        //public async Task VerifyEmployeeDomainSingleRecord_GoodDomain_Success()
        //{
        //    var result = await _employeeService.GetEmployeeByEmployeeAndWeekPeriod(1, 2);
        //    Assert.Contains("entropyzero.com", result.Email);
        //}
    }
}

