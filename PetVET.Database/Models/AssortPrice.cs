using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class AssortPrice
    {
        public int Rowid { get; set; }
        public int? AsspriceOfficeid { get; set; }
        public int? AsspriceAssortid { get; set; }
        public decimal? AsspricePrice { get; set; }
        public DateTime? AsspriceDate { get; set; }
        public int? AsspriceVersion { get; set; }
        public bool? AsspriceNotused { get; set; }
        public DateTime? AsspriceCreatedate { get; set; }
        public string AsspriceCreateby { get; set; }
        public DateTime? AsspriceUpdatedate { get; set; }
        public string AsspriceUpdateby { get; set; }

        public Assortment AsspriceAssort { get; set; }
        public Office AsspriceOffice { get; set; }
    }
}
