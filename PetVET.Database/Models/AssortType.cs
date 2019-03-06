using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class AssortType
    {
        public AssortType()
        {
            Assortment = new HashSet<Assortment>();
        }

        public int Rowid { get; set; }
        public string AsstypCode { get; set; }
        public string AsstypDesc { get; set; }
        public bool? AsstypNotused { get; set; }
        public DateTime? AsstypeCreatedate { get; set; }
        public string AsstypeCreateby { get; set; }
        public DateTime? AsstypeUpdatedate { get; set; }
        public string AsstypeUpdateby { get; set; }

        public virtual ICollection<Assortment> Assortment { get; set; }
    }
}
