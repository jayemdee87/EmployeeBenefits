using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBenefitsAPICore.Models.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal PaycheckDeduction { get; set; }
        public decimal PayCheckAmount { get; set; }

        public List<DependentDto> Dependents { get; set; }
    }
}
