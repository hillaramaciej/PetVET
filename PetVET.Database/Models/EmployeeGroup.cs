using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            Employee = new HashSet<Employee>();
        }

        public int Rowid { get; set; }
        public string EmpgroupCode { get; set; }
        public string EmpgroupDesc { get; set; }
        public bool? EmpgroupNotused { get; set; }
        public DateTime? EmpgroupCreatedate { get; set; }
        public string EmpgroupCreateby { get; set; }
        public DateTime? EmpgroupUpdatedate { get; set; }
        public string EmpgroupUpdateby { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
