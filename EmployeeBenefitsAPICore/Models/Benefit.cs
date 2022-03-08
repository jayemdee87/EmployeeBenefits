using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefitsAPICore.Models
{
    public partial class Benefit
    {
        public Benefit()
        {
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long EmpCost { get; set; }
        public long DependentCost { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
