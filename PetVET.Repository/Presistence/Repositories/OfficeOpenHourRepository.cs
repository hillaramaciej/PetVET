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
    class OfficeOpenHourRepository : Repository<OfficeOpenHour>, IOfficeOpenHourRepository
    {
        private DbSet<OfficeOpenHour> OfficeOpenHour;
        public OfficeOpenHourRepository(DBVETContext context) : base(context)
        {
            OfficeOpenHour = context.OfficeOpenHour;
        }


      
    }
}
