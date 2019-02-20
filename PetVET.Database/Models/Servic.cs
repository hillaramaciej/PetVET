using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Servic
    {
        public Servic()
        {
            EmployeeService = new HashSet<EmployeeService>();
        }

        public int Rowid { get; set; }
        public int? ServicOfficeid { get; set; }
        public string ServicName { get; set; }
        public string ServicDesc { get; set; }
        public int? ServicTypeid { get; set; }
        public decimal? ServicCost { get; set; }
        public decimal? ServicDuration { get; set; }
        public int? ServicTaxid { get; set; }
        public bool? ServicNotused { get; set; }
        public DateTime? ServicCreatedate { get; set; }
        public string ServicCreateby { get; set; }
        public DateTime? ServicUpdatedate { get; set; }
        public string ServicUpdateby { get; set; }

        public Tax ServicTax { get; set; }
        public ICollection<EmployeeService> EmployeeService { get; set; }
    }
}
