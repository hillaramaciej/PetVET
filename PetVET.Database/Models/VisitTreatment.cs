using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class VisitTreatment
    {
        public int Rowid { get; set; }
        public int VitVisid { get; set; }
        public int VitTreid { get; set; }
        public decimal? VitQty { get; set; }
        public decimal? VitCost { get; set; }
        public bool? VitNotused { get; set; }
        public string VitCreuser { get; set; }
        public DateTime? VitCredate { get; set; }
        public string VitModuser { get; set; }
        public DateTime? VitModdate { get; set; }

        public Treatment VitTre { get; set; }
        public Visit VitVis { get; set; }
    }
}
