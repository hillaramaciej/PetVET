using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Visit
    {
        public Visit()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Rowid { get; set; }
        public string VisInterview { get; set; }
        public string VisTreatdesc { get; set; }
        public string VisNote { get; set; }
        public string VisInfo { get; set; }
        public bool? VisSendcheck { get; set; }
        public decimal? VisWeight { get; set; }
        public DateTime? VisCreatedate { get; set; }
        public string VisCreateby { get; set; }
        public DateTime? VisUpdatedate { get; set; }
        public string VisUpdateby { get; set; }

        public ICollection<Invoice> Invoice { get; set; }
    }
}
