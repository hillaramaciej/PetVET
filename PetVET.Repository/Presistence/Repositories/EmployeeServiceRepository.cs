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
    class EmployeeServiceRepository : Repository<EmployeeService>, IEmployeeServiceRepository
    {
        private DbSet<EmployeeService> EmployeeService;
        public EmployeeServiceRepository(DBVETContext context) : base(context)
        {
            EmployeeService = context.EmployeeService;
        }

    }
}
