using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Vet
    {
        public Vet()
        {
            DepartmentVetHarm = new HashSet<DepartmentVetHarm>();
            OfficeDepartmentVet = new HashSet<OfficeDepartmentVet>();
            Visit = new HashSet<Visit>();
        }

        public int Rowid { get; set; }
        public string VetName { get; set; }
        public string VetLastname { get; set; }
        public string VetEmail { get; set; }
        public string VetPhone { get; set; }
        public string VetTxt01 { get; set; }
        public string VetTxt02 { get; set; }
        public string VetTxt03 { get; set; }
        public string VetTxt04 { get; set; }
        public string VetTxt05 { get; set; }
        public DateTime? VetDtx01 { get; set; }
        public DateTime? VetDtx02 { get; set; }
        public DateTime? VetDtx03 { get; set; }
        public DateTime? VetDtx04 { get; set; }
        public DateTime? VetDtx05 { get; set; }
        public decimal? VetNtx01 { get; set; }
        public decimal? VetNtx02 { get; set; }
        public decimal? VetNtx03 { get; set; }
        public decimal? VetNtx04 { get; set; }
        public decimal? VetNtx05 { get; set; }
        public bool? VetNotused { get; set; }
        public string VetCreuser { get; set; }
        public DateTime? VetCredate { get; set; }
        public string VetModuser { get; set; }
        public DateTime? VetModdate { get; set; }

        public ICollection<DepartmentVetHarm> DepartmentVetHarm { get; set; }
        public ICollection<OfficeDepartmentVet> OfficeDepartmentVet { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
