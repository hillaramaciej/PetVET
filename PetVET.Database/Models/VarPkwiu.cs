using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class VarPkwiu
    {
        public VarPkwiu()
        {
            Treatment = new HashSet<Treatment>();
        }

        public string PkwiuCode { get; set; }
        public string PkwiuDesc { get; set; }
        public bool? PkwiuNotused { get; set; }
        public string PkwiuCreuser { get; set; }
        public DateTime? PkwiuCredate { get; set; }
        public string PkwiuModuser { get; set; }
        public DateTime? PkwiuModdate { get; set; }

        public ICollection<Treatment> Treatment { get; set; }
    }
}
