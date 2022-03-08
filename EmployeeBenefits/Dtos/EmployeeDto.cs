using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBenefits.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Dependents = new List<DependentDto>();
        }

        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal PaycheckDeduction { get; set; }
        public decimal PayCheckAmount { get; set; }

        public List<DependentDto> Dependents { get; set; }
    }
}
