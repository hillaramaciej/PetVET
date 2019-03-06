using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Assortment
    {
        public Assortment()
        {
            AssortPrice = new HashSet<AssortPrice>();
            InvoiceAssortment = new HashSet<InvoiceAssortment>();
        }

        public int Rowid { get; set; }
        public string AssortName { get; set; }
        public string AssortDesc { get; set; }
        public byte? AssortPrescription { get; set; }
        public int? AssortTypid { get; set; }
        public DateTime? AssortCreatedate { get; set; }
        public string AssortCreateby { get; set; }
        public DateTime? AssortUpdatedate { get; set; }
        public string AssortUpdateby { get; set; }

        public virtual AssortType AssortTyp { get; set; }
        public virtual ICollection<AssortPrice> AssortPrice { get; set; }
        public virtual ICollection<InvoiceAssortment> InvoiceAssortment { get; set; }
    }
}
