using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Office
    {
        public Office()
        {
            AssortPrice = new HashSet<AssortPrice>();
            Equipemnt = new HashSet<Equipemnt>();
            OfficeCustomer = new HashSet<OfficeCustomer>();
            OfficeHoliday = new HashSet<OfficeHoliday>();
            OfficeOpenHour = new HashSet<OfficeOpenHour>();
        }

        public int Rowid { get; set; }
        public int? OfficeCompanyid { get; set; }
        public string OfficeStreet { get; set; }
        public string OfficeHouse { get; set; }
        public string OfficeFlat { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeCitycode { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeEmail { get; set; }
        public bool? OfficeNotused { get; set; }
        public DateTime? OfficeCreatedate { get; set; }
        public string OfficeCreateby { get; set; }
        public DateTime? OfficeUpdatedate { get; set; }
        public string OfficeUpdateby { get; set; }

        public Company OfficeCompany { get; set; }
        public ICollection<AssortPrice> AssortPrice { get; set; }
        public ICollection<Equipemnt> Equipemnt { get; set; }
        public ICollection<OfficeCustomer> OfficeCustomer { get; set; }
        public ICollection<OfficeHoliday> OfficeHoliday { get; set; }
        public ICollection<OfficeOpenHour> OfficeOpenHour { get; set; }
    }
}
