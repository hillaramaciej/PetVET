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

        public CustomerAnimal InvCustomeranimal { get; set; }
        public Employee InvEmp { get; set; }
        public MethodPay InvMethodpay { get; set; }
        public Visit InvVisit { get; set; }
        public ICollection<InvoiceAssortment> InvoiceAssortment { get; set; }
        public ICollection<InvoiceService> InvoiceService { get; set; }
    }
}
