using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class InvoiceAssortment
    {
        public int Rowid { get; set; }
        public int? InvassortInvoiceid { get; set; }
        public int? InvassortAssortid { get; set; }
        public decimal? InvassortQty { get; set; }
        public decimal? InvassortPortion { get; set; }
        public int? InvassortFreq { get; set; }
        public int? InvassortHowlong { get; set; }
        public int? InvassortDiscount { get; set; }
        public bool? InvassortNotused { get; set; }
        public DateTime? InvassortCreatedate { get; set; }
        public string InvassortCreateby { get; set; }
        public DateTime? InvassortUpdatedate { get; set; }
        public string InvassortUpdateby { get; set; }

        public Assortment InvassortAssort { get; set; }
        public Invoice InvassortInvoice { get; set; }
    }
}
