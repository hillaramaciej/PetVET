using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Assortment
    {
        public Assortment()
        {
            VisitMedicines = new HashSet<VisitMedicines>();
        }

        public int Rowid { get; set; }
        public int AssOdtid { get; set; }
        public string AssCode { get; set; }
        public string AssDesc { get; set; }
        public string AssTxt01 { get; set; }
        public string AssTxt02 { get; set; }
        public string AssTxt03 { get; set; }
        public string AssTxt04 { get; set; }
        public string AssTxt05 { get; set; }
        public DateTime? AssDtx01 { get; set; }
        public DateTime? AssDtx02 { get; set; }
        public DateTime? AssDtx03 { get; set; }
        public DateTime? AssDtx04 { get; set; }
        public DateTime? AssDtx05 { get; set; }
        public decimal? AssNtx01 { get; set; }
        public decimal? AssNtx02 { get; set; }
        public decimal? AssNtx03 { get; set; }
        public decimal? AssNtx04 { get; set; }
        public decimal? AssNtx05 { get; set; }
        public bool? AssNotused { get; set; }
        public string AssCreuser { get; set; }
        public DateTime? AssCredate { get; set; }
        public string AssModuser { get; set; }
        public DateTime? AssModdate { get; set; }

        public OfficeDepartment AssOdt { get; set; }
        public ICollection<VisitMedicines> VisitMedicines { get; set; }
    }
}
