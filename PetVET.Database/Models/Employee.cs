using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeHoliday = new HashSet<EmployeeHoliday>();
            EmployeeOffice = new HashSet<EmployeeOffice>();
            EmployeeOpenHour = new HashSet<EmployeeOpenHour>();
            EmployeeService = new HashSet<EmployeeService>();
            Invoice = new HashSet<Invoice>();
        }

        public int Rowid { get; set; }
        public string EmplName { get; set; }
        public string EmplLastname { get; set; }
        public string EmplEmail { get; set; }
        public string EmplPwz { get; set; }
        public string EmplAdress { get; set; }
        public string EmplPhone { get; set; }
        public DateTime? EmplBegindate { get; set; }
        public string EmplPesel { get; set; }
        public int? EmplGroupid { get; set; }
        public byte? EmplAccountenable { get; set; }
        public bool? EmplNotused { get; set; }
        public DateTime? EmplCreatedate { get; set; }
        public string EmplCreateby { get; set; }
        public DateTime? EmplUpdatedate { get; set; }
        public string EmplUpdateby { get; set; }

        public virtual EmployeeGroup EmplGroup { get; set; }
        public virtual ICollection<EmployeeHoliday> EmployeeHoliday { get; set; }
        public virtual ICollection<EmployeeOffice> EmployeeOffice { get; set; }
        public virtual ICollection<EmployeeOpenHour> EmployeeOpenHour { get; set; }
        public virtual ICollection<EmployeeService> EmployeeService { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
