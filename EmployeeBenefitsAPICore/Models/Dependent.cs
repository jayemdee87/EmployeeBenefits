using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefitsAPICore.Models
{
    public partial class Dependent
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
