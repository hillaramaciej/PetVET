using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Tax
    {
        public Tax()
        {
            Servic = new HashSet<Servic>();
        }

        public int Rowid { get; set; }
        public string TaxCode { get; set; }
        public decimal? TaxValue { get; set; }
        public bool? TaxNotused { get; set; }
        public DateTime? TaxCreatedate { get; set; }
        public string TaxCreateby { get; set; }
        public DateTime? TaxUpdatedate { get; set; }
        public string TaxUpdateby { get; set; }

        public virtual ICollection<Servic> Servic { get; set; }
    }
}
