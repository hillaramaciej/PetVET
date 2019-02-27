using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Equipemnt
    {
        public int Rowid { get; set; }
        public int? EquipOfficeid { get; set; }
        public string EquipName { get; set; }
        public string EquipSerialnum { get; set; }
        public DateTime? EquipWarrantydata { get; set; }
        public string EquipDesc { get; set; }
        public int? EquipTypeid { get; set; }
        public DateTime? EquipCreatedate { get; set; }
        public string EquipCreateby { get; set; }
        public DateTime? EquipUpdatedate { get; set; }
        public string EquipUpdateby { get; set; }

        public virtual Office EquipOffice { get; set; }
        public virtual EquipemntType EquipType { get; set; }
    }
}
