using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class ServiceType
    {
        public int Rowid { get; set; }
        public string ServicetypCode { get; set; }
        public string ServicetypDesc { get; set; }
        public bool? ServicetypNotused { get; set; }
        public DateTime? ServicetypeCreatedate { get; set; }
        public string ServicetypeCreateby { get; set; }
        public DateTime? ServicetypeUpdatedate { get; set; }
        public string ServicetypeUpdateby { get; set; }
    }
}
