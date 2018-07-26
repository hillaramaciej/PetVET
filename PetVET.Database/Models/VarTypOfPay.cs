using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class VarTypOfPay
    {
        public VarTypOfPay()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Rowid { get; set; }
        public int? VtopDay { get; set; }
        public string VtopDesc { get; set; }
        public bool? VtopNotused { get; set; }
        public string VtopCreuser { get; set; }
        public DateTime? VtopCredate { get; set; }
        public string VtopModuser { get; set; }
        public DateTime? VtopModdate { get; set; }

        public ICollection<Invoice> Invoice { get; set; }
    }
}
