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
    class OfficeHolidayRepository : Repository<OfficeHoliday>, IOfficeHolidayRepository
    {
        private DbSet<OfficeHoliday> OfficeHoliday;
        public OfficeHolidayRepository(DBVETContext context) : base(context)
        {
            OfficeHoliday = context.OfficeHoliday;
        }
    }
}
