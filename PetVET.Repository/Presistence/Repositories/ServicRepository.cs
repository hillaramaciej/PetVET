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
    class ServicRepository : Repository<Servic>, IServicRepository
    {
        private DbSet<Servic> Servic;
        public ServicRepository(DBVETContext context) : base(context)
        {
            Servic = context.Servic;
        }


      
    }
}
