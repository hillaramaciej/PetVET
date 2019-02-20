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
    class EmployeeGroupRepository : Repository<EmployeeGroup>, IEmployeeGroupRepository
    {
        private DbSet<EmployeeGroup> EmployeeGroup;
        public EmployeeGroupRepository(DBVETContext context) : base(context)
        {
            EmployeeGroup = context.EmployeeGroup;
        }


        public DBVETContext GromContext
        {
            get
            {
                return Context as DBVETContext;
            }
        }


    }
}
