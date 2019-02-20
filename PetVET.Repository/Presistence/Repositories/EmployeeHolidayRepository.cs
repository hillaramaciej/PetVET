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
    class EmployeeHolidayRepository : Repository<EmployeeHoliday>, IEmployeeHolidayRepository
    {
        private DbSet<EmployeeHoliday> EmployeeHoliday;
        public EmployeeHolidayRepository(DBVETContext context) : base(context)
        {
            EmployeeHoliday = context.EmployeeHoliday;
        }



      
    }
}
