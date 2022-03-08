using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefitsAPICore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Dependents = new HashSet<Dependent>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal PayCheckDeduction { get; set; }
        public decimal PayCheckAmount { get; set; }

        public virtual ICollection<Dependent> Dependents { get; set; }
    }
}
