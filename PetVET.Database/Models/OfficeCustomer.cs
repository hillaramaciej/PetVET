using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class OfficeCustomer
    {
        public int Rowid { get; set; }
        public int? OffcustomCustomerid { get; set; }
        public int? OffcustomOfficeid { get; set; }
        public bool? OffcustomNotused { get; set; }
        public DateTime? OffcustomCreatedate { get; set; }
        public string OffcustomCreateby { get; set; }
        public DateTime? OffcustomUpdatedate { get; set; }
        public string OffcustomUpdateby { get; set; }

        public Customer OffcustomCustomer { get; set; }
        public Office OffcustomOffice { get; set; }
    }
}
