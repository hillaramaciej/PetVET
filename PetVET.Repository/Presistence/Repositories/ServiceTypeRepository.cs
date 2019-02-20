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
    class ServiceTypeRepository : Repository<ServiceType>, IServiceTypeRepository
    {
        private DbSet<ServiceType> ServiceType;
        public ServiceTypeRepository(DBVETContext context) : base(context)
        {
            ServiceType = context.ServiceType;
        }


      
    }
}
