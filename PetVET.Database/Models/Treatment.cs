using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Treatment
    {
        public Treatment()
        {
            VisitTreatment = new HashSet<VisitTreatment>();
        }

        public int Rowid { get; set; }
        public int TreOdtid { get; set; }
        public string TreDescription { get; set; }
        public decimal? TreCost { get; set; }
        public string TrePkwiu { get; set; }
        public bool? TreNotused { get; set; }
        public string TreCreuser { get; set; }
        public DateTime? TreCredate { get; set; }
        public string TreModuser { get; set; }
        public DateTime? TreModdate { get; set; }

        public OfficeDepartment TreOdt { get; set; }
        public VarPkwiu TrePkwiuNavigation { get; set; }
        public ICollection<VisitTreatment> VisitTreatment { get; set; }
    }
}
