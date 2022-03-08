using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefitsAPICore.Models
{
    public partial class Salary
    {
        public Salary()
        {
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public long Amount { get; set; }
        public int AnnualPaychecks { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
