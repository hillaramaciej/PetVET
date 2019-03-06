using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EmployeeOffice
    {
        public int Rowid { get; set; }
        public int? EmpofficeEmpid { get; set; }
        public int? EmpofficeOfficeid { get; set; }
        public DateTime? EmpofficeBegindate { get; set; }
        public DateTime? EmpofficeEnddate { get; set; }
        public bool? EmpofficeNotused { get; set; }
        public DateTime? EmpofficeCreatedate { get; set; }
        public string EmpofficeCreateby { get; set; }
        public DateTime? EmpofficeUpdatedate { get; set; }
        public string EmpofficeUpdateby { get; set; }

        public virtual Employee EmpofficeEmp { get; set; }
        public virtual Office EmpofficeOffice { get; set; }
    }
}
