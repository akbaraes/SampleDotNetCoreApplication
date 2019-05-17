using CodeSnippetSample.Controllers;
using DALLayer;
using DALLayer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLayer.EmployeeService;
using System;
using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeSnippetSample.Models;

namespace CodeSnippetSample.Test
{
    public class EmployeeControllerTest
    {

        private AppDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new AppDbContext(options);

            var emp1 = new Employee { Id = 1, FirstName = "Akbar", LastName = "Jinna" };
            var emp2 = new Employee { Id = 1, FirstName = "Jankeer", LastName = "Jinna" };
            context.Employees.Add(emp1);
            context.Employees.Add(emp2);

            context.SaveChanges();

            return context;
        }




        [Fact(DisplayName = "Index should return default view")]
        public void Index_should_return_default_view()
        {
            var expected = new List<Employee>();

            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(ss => ss.GetAllEmployees()).Returns(expected);


            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<Employee, EmployeeModel>(It.IsAny<Employee>()))
     .Returns(new EmployeeModel());

            using (var controller = new EmployeesController(employeeService.Object, mapper.Object))
            {
                var result = controller.Index() as ViewResult;

                Assert.NotNull(result);
                Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
        }
    }
}
