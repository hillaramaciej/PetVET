using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class DepartmentVetHarm
    {
        public int Rowid { get; set; }
        public int DvhDepartmentid { get; set; }
        public int DvhVet { get; set; }
        public DateTime? DvhBegin { get; set; }
        public DateTime? DvhEnd { get; set; }
        public bool? DvhNotused { get; set; }
        public string DvhCreuser { get; set; }
        public DateTime? DvhCredate { get; set; }
        public string DvhModuser { get; set; }
        public DateTime? DvhModdate { get; set; }

        public OfficeDepartment DvhDepartment { get; set; }
        public Vet DvhVetNavigation { get; set; }
    }
}
