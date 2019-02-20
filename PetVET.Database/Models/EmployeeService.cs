using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EmployeeService
    {
        public int Rowid { get; set; }
        public int? EmpserviceServiceid { get; set; }
        public int? EmpserviceEmploeeyid { get; set; }
        public bool? EmpserviceNotused { get; set; }
        public DateTime? EmpserviceCreatedate { get; set; }
        public string EmpserviceCreateby { get; set; }
        public DateTime? EmpserviceUpdatedate { get; set; }
        public string EmpserviceUpdateby { get; set; }

        public Employee EmpserviceEmploeey { get; set; }
        public Servic EmpserviceService { get; set; }
    }
}
