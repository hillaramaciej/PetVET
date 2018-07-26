using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class OfficeDepartment
    {
        public OfficeDepartment()
        {
            Assortment = new HashSet<Assortment>();
            DepartmentVetHarm = new HashSet<DepartmentVetHarm>();
            Treatment = new HashSet<Treatment>();
            Visit = new HashSet<Visit>();
        }

        public int Rowid { get; set; }
        public int OdtOfficeid { get; set; }
        public string OdtDescription { get; set; }
        public string OdtAddress { get; set; }
        public string OdtZipcode { get; set; }
        public string OdtCity { get; set; }
        public string OdtPhone { get; set; }
        public string OdtEmail { get; set; }
        public string OdtTxt01 { get; set; }
        public string OdtTxt02 { get; set; }
        public string OdtTxt03 { get; set; }
        public string OdtTxt04 { get; set; }
        public string OdtTxt05 { get; set; }
        public DateTime? OdtDtx01 { get; set; }
        public DateTime? OdtDtx02 { get; set; }
        public DateTime? OdtDtx03 { get; set; }
        public DateTime? OdtDtx04 { get; set; }
        public DateTime? OdtDtx05 { get; set; }
        public decimal? OdtNtx01 { get; set; }
        public decimal? OdtNtx02 { get; set; }
        public decimal? OdtNtx03 { get; set; }
        public decimal? OdtNtx04 { get; set; }
        public decimal? OdtNtx05 { get; set; }
        public bool? OdtNotused { get; set; }
        public string OdtCreuser { get; set; }
        public DateTime? OdtCredate { get; set; }
        public string OdtModuser { get; set; }
        public DateTime? OdtModdate { get; set; }

        public Office OdtOffice { get; set; }
        public ICollection<Assortment> Assortment { get; set; }
        public ICollection<DepartmentVetHarm> DepartmentVetHarm { get; set; }
        public ICollection<Treatment> Treatment { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
