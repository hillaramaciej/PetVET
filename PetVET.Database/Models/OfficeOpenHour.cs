using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class OfficeOpenHour
    {
        public int Rowid { get; set; }
        public int? OffopenOfficeid { get; set; }
        public byte? OffopenWeekday { get; set; }
        public DateTime? OffopenBegindate { get; set; }
        public DateTime? OffopenEnddate { get; set; }
        public byte? OffopenFlag { get; set; }
        public bool? OffopenNotused { get; set; }
        public DateTime? OffopenCreatedate { get; set; }
        public string OffopenCreateby { get; set; }
        public DateTime? OffopenUpdatedate { get; set; }
        public string OffopenUpdateby { get; set; }

        public Office OffopenOffice { get; set; }
    }
}
