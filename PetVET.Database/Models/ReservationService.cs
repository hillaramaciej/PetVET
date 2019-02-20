using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class ReservationService
    {
        public int Rowid { get; set; }
        public int? ReserserviceReservationid { get; set; }
        public int? ReserserviceServiceid { get; set; }
        public bool? ReserserviceNotused { get; set; }
        public DateTime? ReserserviceCreatedate { get; set; }
        public string ReserserviceCreateby { get; set; }
        public DateTime? ReserserviceUpdatedate { get; set; }
        public string ReserserviceUpdateby { get; set; }

        public Reservation ReserserviceReservation { get; set; }
    }
}
