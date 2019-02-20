using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeHoliday = new HashSet<EmployeeHoliday>();
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

        public EmployeeGroup EmplGroup { get; set; }
        public ICollection<EmployeeHoliday> EmployeeHoliday { get; set; }
        public ICollection<EmployeeOpenHour> EmployeeOpenHour { get; set; }
        public ICollection<EmployeeService> EmployeeService { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
    }
}
