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
    class EmployeeOpenHourRepository : Repository<EmployeeOpenHour>, IEmployeeOpenHourRepository
    {
        private DbSet<EmployeeOpenHour> EmployeeOpenHour;
        public EmployeeOpenHourRepository(DBVETContext context) : base(context)
        {
            EmployeeOpenHour = context.EmployeeOpenHour;
        }


    }
}
