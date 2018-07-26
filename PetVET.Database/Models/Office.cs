using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Office
    {
        public Office()
        {
            OfficeDepartment = new HashSet<OfficeDepartment>();
            OfficeDepartmentVet = new HashSet<OfficeDepartmentVet>();
        }

        public int Rowid { get; set; }
        public string OffDescription { get; set; }
        public string OffAddress { get; set; }
        public string OffZipcode { get; set; }
        public string OffCity { get; set; }
        public string OffNip { get; set; }
        public string OffImg01 { get; set; }
        public string OffRegon { get; set; }
        public string OffTxt01 { get; set; }
        public string OffTxt02 { get; set; }
        public string OffTxt03 { get; set; }
        public string OffTxt04 { get; set; }
        public string OffTxt05 { get; set; }
        public DateTime? OffDtx01 { get; set; }
        public DateTime? OffDtx02 { get; set; }
        public DateTime? OffDtx03 { get; set; }
        public DateTime? OffDtx04 { get; set; }
        public DateTime? OffDtx05 { get; set; }
        public decimal? OffNtx01 { get; set; }
        public decimal? OffNtx02 { get; set; }
        public decimal? OffNtx03 { get; set; }
        public decimal? OffNtx04 { get; set; }
        public decimal? OffNtx05 { get; set; }
        public bool? OffNotused { get; set; }
        public string OffCreuser { get; set; }
        public DateTime? OffCredate { get; set; }
        public string OffModuser { get; set; }
        public DateTime? OffModdate { get; set; }

        public ICollection<OfficeDepartment> OfficeDepartment { get; set; }
        public ICollection<OfficeDepartmentVet> OfficeDepartmentVet { get; set; }
    }
}
