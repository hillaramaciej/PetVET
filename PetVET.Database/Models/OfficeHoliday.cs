using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class OfficeHoliday
    {
        public int Rowid { get; set; }
        public int? OffholiOfficeid { get; set; }
        public DateTime? OffholiDate { get; set; }
        public bool? OffholiNotused { get; set; }
        public DateTime? OffholiCreatedate { get; set; }
        public string OffholiCreateby { get; set; }
        public DateTime? OffholiUpdatedate { get; set; }
        public string OffholiUpdateby { get; set; }

        public virtual Office OffholiOffice { get; set; }
    }
}
