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
    class ReservationServiceRepository : Repository<ReservationService>, IReservationServiceRepository
    {
        private DbSet<ReservationService> ReservationService;
        public ReservationServiceRepository(DBVETContext context) : base(context)
        {
            ReservationService = context.ReservationService;
        }


      
    }
}
