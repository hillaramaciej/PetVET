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
    class OfficeCustomerRepository : Repository<OfficeCustomer>, IOfficeCustomerRepository
    {
        private DbSet<OfficeCustomer> OfficeCustomer;
        public OfficeCustomerRepository(DBVETContext context) : base(context)
        {
            OfficeCustomer = context.OfficeCustomer;
        }
      
    }
}
