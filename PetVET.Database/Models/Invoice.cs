using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Invoice
    {
        public int Rowid { get; set; }
        public string InvCode { get; set; }
        public int InvVisit { get; set; }
        public DateTime? InvDate { get; set; }
        public DateTime? InvSelldate { get; set; }
        public int? InvTypid { get; set; }
        public bool? InvNotused { get; set; }
        public string InvCreuser { get; set; }
        public DateTime? InvCredate { get; set; }
        public string InvModuser { get; set; }
        public DateTime? InvModdate { get; set; }

        public VarTypOfPay InvTyp { get; set; }
        public Visit InvVisitNavigation { get; set; }
    }
}
