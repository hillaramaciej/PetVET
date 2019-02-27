using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationService = new HashSet<ReservationService>();
        }

        public int Rowid { get; set; }
        public int? ReservOfficeid { get; set; }
        public int? ReservEmpid { get; set; }
        public int? ReservAnimalid { get; set; }
        public string ReservStatus { get; set; }
        public DateTime? ReservDate { get; set; }
        public bool? ReservNotused { get; set; }
        public DateTime? ReservCreatedate { get; set; }
        public string ReservCreateby { get; set; }
        public DateTime? ReservUpdatedate { get; set; }
        public string ReservUpdateby { get; set; }

        public virtual ICollection<ReservationService> ReservationService { get; set; }
    }
}
