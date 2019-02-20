using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class EquipemntType
    {
        public EquipemntType()
        {
            Equipemnt = new HashSet<Equipemnt>();
        }

        public int Rowid { get; set; }
        public string EquiptypeCode { get; set; }
        public string EquiptypeDesc { get; set; }
        public bool? EquiptypeNotused { get; set; }
        public DateTime? EquiptypeCreatedate { get; set; }
        public string EquiptypeCreateby { get; set; }
        public DateTime? EquiptypeUpdatedate { get; set; }
        public string EquiptypeUpdateby { get; set; }

        public ICollection<Equipemnt> Equipemnt { get; set; }
    }
}
