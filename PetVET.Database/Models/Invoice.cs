using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceAssortment = new HashSet<InvoiceAssortment>();
            InvoiceService = new HashSet<InvoiceService>();
        }

        public int Rowid { get; set; }
        public int? InvOfficeid { get; set; }
        public string InvCode { get; set; }
        public byte? InvStatus { get; set; }
        public decimal? InvCost { get; set; }
        public int? InvEmpid { get; set; }
        public int? InvCustomeranimalid { get; set; }
        public int? InvMethodpayid { get; set; }
        public int? InvVisitid { get; set; }
        public DateTime? InvCreatedate { get; set; }
        public string InvCreateby { get; set; }
        public DateTime? InvUpdatedate { get; set; }
        public string InvUpdateby { get; set; }

        public virtual CustomerAnimal InvCustomeranimal { get; set; }
        public virtual Employee InvEmp { get; set; }
        public virtual MethodPay InvMethodpay { get; set; }
        public virtual Visit InvVisit { get; set; }
        public virtual ICollection<InvoiceAssortment> InvoiceAssortment { get; set; }
        public virtual ICollection<InvoiceService> InvoiceService { get; set; }
    }
}
