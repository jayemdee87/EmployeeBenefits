using EmployeeBenefitsAPICore.Interfaces;
using EmployeeBenefitsAPICore.Models;
using EmployeeBenefitsAPICore.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBenefitsAPICore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeBenefitsContext _dbContext;

        private readonly decimal paycheckAmount = 2000;
        private readonly decimal employeeDeductions = 1000;
        private readonly decimal dependentDeductions = 500;
        private readonly decimal annualPaychecks = 26;
        private readonly string discountLetter = "a";
        private readonly decimal discountAmount = 0.1M;

        public EmployeeService(EmployeeBenefitsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            employees = _dbContext.Employees.Include(x => x.Dependents)
                                                   .ToList();

            return employees;
        }

        public Employee GetEmployee(long id)
        {
            Employee employee;
            employee = _dbContext.Employees.Include(x => x.Dependents)
                                          .SingleOrDefault(x => x.Id == id);

            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            var readyToSave = CalculateSalary(employee);

            _dbContext.Add(readyToSave);
            _dbContext.SaveChanges();
            
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updateEmployee = _dbContext.Employees.Include(x => x.Dependents)
                                                    .SingleOrDefault(x => x.Id == employee.Id);

            foreach(var dependent in employee.Dependents)
            {
                if (dependent.Id == 0)
                {
                    updateEmployee.Dependents.Add(dependent);
                }
                else
                {
                    var updateDependent = updateEmployee.Dependents.SingleOrDefault(x => x.Id == dependent.Id);
                }
            }

            updateEmployee = CalculateSalary(updateEmployee);

            _dbContext.SaveChanges();

            return employee;
        }

        public Employee CalculateSalary(Employee employee)
        {
            employee.AnnualSalary = Math.Round(paycheckAmount * annualPaychecks);

            var deductions = employeeDeductions;
            if (employee.FirstName.Substring(0, 1).ToLower() == discountLetter)
            {
                deductions -= Math.Round(deductions * discountAmount, 2);
            }

            foreach (var dependent in employee.Dependents)
            {
                deductions += dependentDeductions;
                if (dependent.FirstName.Substring(0, 1).ToLower() == discountLetter)
                {
                    var dependentDiscount = dependentDeductions * discountAmount;
                    deductions -= dependentDiscount;
                }
            }

            employee.PayCheckDeduction = Math.Round(deductions / annualPaychecks, 2);
            employee.PayCheckAmount = paycheckAmount - employee.PayCheckDeduction;

            return employee;
        }
    }
}
