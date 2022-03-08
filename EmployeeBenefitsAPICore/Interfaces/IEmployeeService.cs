using EmployeeBenefitsAPICore.Models;
using EmployeeBenefitsAPICore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBenefitsAPICore.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(long id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
    }
}
