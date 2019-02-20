using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EmployeeOpenHour
    {
        public int Rowid { get; set; }
        public int? EmplopenEmpid { get; set; }
        public DateTime? EmplopenBegindate { get; set; }
        public DateTime? EmplopenEnddate { get; set; }
        public byte? EmplopenFlag { get; set; }
        public bool? EmplopenNotused { get; set; }
        public DateTime? EmplopenCreatedate { get; set; }
        public string EmplopenCreateby { get; set; }
        public DateTime? EmplopenUpdatedate { get; set; }
        public string EmplopenUpdateby { get; set; }

        public Employee EmplopenEmp { get; set; }
    }
}
