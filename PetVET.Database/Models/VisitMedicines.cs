using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class VisitMedicines
    {
        public int Rowid { get; set; }
        public int VimVisid { get; set; }
        public int VimAssid { get; set; }
        public decimal? VimQty { get; set; }
        public decimal? VimCost { get; set; }
        public string VimDose { get; set; }
        public bool? VimNotused { get; set; }
        public string VimCreuser { get; set; }
        public DateTime? VimCredate { get; set; }
        public string VimModuser { get; set; }
        public DateTime? VimModdate { get; set; }

        public Assortment VimAss { get; set; }
        public Visit VimVis { get; set; }
    }
}
