using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class OfficeDepartmentVet
    {
        public int Rowid { get; set; }
        public int OdvOdtid { get; set; }
        public int OdvVetid { get; set; }
        public DateTime? OdvDatabegin { get; set; }
        public DateTime? OdvDataend { get; set; }
        public string OdvDescription { get; set; }
        public bool? OdvNotused { get; set; }
        public string OdvCreuser { get; set; }
        public DateTime? OdvCredate { get; set; }
        public string OdvModuser { get; set; }
        public DateTime? OdvModdate { get; set; }

        public Office OdvOdt { get; set; }
        public Vet OdvVet { get; set; }
    }
}
