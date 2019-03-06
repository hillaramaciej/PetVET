using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EmployeeHoliday
    {
        public int Rowid { get; set; }
        public int? EmpholiEmpid { get; set; }
        public DateTime? EmpholiDate { get; set; }
        public bool? EmpholiNotused { get; set; }
        public DateTime? EmpholiCreatedate { get; set; }
        public string EmpholiCreateby { get; set; }
        public DateTime? EmpholiUpdatedate { get; set; }
        public string EmpholiUpdateby { get; set; }

        public virtual Employee EmpholiEmp { get; set; }
    }
}
