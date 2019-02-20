using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class InvoiceService
    {
        public int Rowid { get; set; }
        public int? InvserviceInvoiceid { get; set; }
        public int? InvserviceServiceid { get; set; }
        public decimal? InvserviceQty { get; set; }
        public int? InvserviceDiscount { get; set; }
        public bool? InvserviceNotused { get; set; }
        public DateTime? InvserviceCreatedate { get; set; }
        public string InvserviceCreateby { get; set; }
        public DateTime? InvserviceUpdatedate { get; set; }
        public string InvserviceUpdateby { get; set; }

        public Invoice InvserviceInvoice { get; set; }
    }
}
