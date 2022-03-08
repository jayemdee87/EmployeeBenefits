using NUnit.Framework;
using EmployeeBenefitsAPICore.Services;
using EmployeeBenefitsAPICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using FluentAssertions;

namespace EmployeeBenefits.Tests
{
    public class Tests
    {
        private EmployeeService _employeeService;
        private DbContextOptions<EmployeeBenefitsContext> dbContextOptions = new DbContextOptionsBuilder<EmployeeBenefitsContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeBenefitsDb")
            .Options;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();

            _employeeService = new EmployeeService(new EmployeeBenefitsContext(dbContextOptions));
        }

        private void SeedDb()
        {
            using var context = new EmployeeBenefitsContext(dbContextOptions);
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Test", LastName = "Employee", AnnualSalary = 52000, PayCheckDeduction = 38.46M, PayCheckAmount = 1961.54M },
                new Employee { Id = 2, FirstName = "Another", LastName = "Employee", AnnualSalary = 52000, PayCheckDeduction = 34.61M, PayCheckAmount = 1965.29M },
                new Employee { Id = 3, FirstName = "Fake", LastName = "Employees", AnnualSalary = 52000, PayCheckDeduction = 55.80M, PayCheckAmount = 1944.20M },
            };

            var dependents = new List<Dependent>
            {
                new Dependent { Id = 1, FirstName = "Another", LastName = "Employees", EmployeeId = 3 }
            };

            context.AddRange(employees);
            context.AddRange(dependents);

            context.SaveChanges();
        }

        [Test]
        public void getemployees()
        {
            using var context = new EmployeeBenefitsContext(dbContextOptions);
            var employees = _employeeService.GetEmployees();

            employees.Should().NotBeEmpty();
            employees[2].Dependents.Should().HaveCount(1);
        }

        [Test]
        public void getemployee()
        {
            using var context = new EmployeeBenefitsContext(dbContextOptions);
            var employee = _employeeService.GetEmployee(3);

            employee.Should().NotBeNull();
            employee.Dependents.Should().NotBeNull();
            employee.Dependents.Should().HaveCount(1);
        }

        [Test]
        public void addemployee_nodependents()
        {
            var employee = new Employee
            {
                FirstName = "Albert",
                LastName = "Test"
            };

            using var context = new EmployeeBenefitsContext(dbContextOptions);
            var savedEmployee = _employeeService.AddEmployee(employee);

            savedEmployee.Id.Should().Be(4);
            savedEmployee.AnnualSalary.Should().Be(52000);
            savedEmployee.PayCheckDeduction.Should().Be(34.62M);
            savedEmployee.PayCheckAmount.Should().Be(1965.38M);
            savedEmployee.Dependents.Should().HaveCount(0);
        }

        [Test]
        public void addemployee_onedependent()
        {
            var employee = new Employee
            {
                FirstName = "Albert",
                LastName = "Test",
                Dependents = new List<Dependent> { 
                    new Dependent { FirstName = "Test", LastName = "Test" }
                }
            };

            using var context = new EmployeeBenefitsContext(dbContextOptions);
            var savedEmployee = _employeeService.AddEmployee(employee);

            savedEmployee.Id.Should().Be(5);
            savedEmployee.AnnualSalary.Should().Be(52000);
            savedEmployee.PayCheckDeduction.Should().Be(53.85M);
            savedEmployee.PayCheckAmount.Should().Be(1946.15M);
            savedEmployee.Dependents.Should().HaveCount(1);
        }
    }
}