using Microsoft.EntityFrameworkCore;
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PetVET.Repository
{
    class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private DbSet<Reservation> Reservation;
        public ReservationRepository(DBVETContext context) : base(context)
        {
            Reservation = context.Reservation;
        }



      
    }
}
