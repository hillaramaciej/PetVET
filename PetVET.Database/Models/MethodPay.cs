using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class MethodPay
    {
        public MethodPay()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Rowid { get; set; }
        public string MetpayCode { get; set; }
        public int? MetpayDay { get; set; }
        public bool? MetpayNotused { get; set; }
        public DateTime? MetpayCreatedate { get; set; }
        public string MetpayCreateby { get; set; }
        public DateTime? MetpayUpdatedate { get; set; }
        public string MetpayUpdateby { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
