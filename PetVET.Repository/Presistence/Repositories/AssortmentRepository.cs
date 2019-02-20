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
    class AssortmentRepository : Repository<Assortment>, IAssortmentRepository
    {
        private DbSet<Assortment> Assortment;
        public AssortmentRepository(DBVETContext context) : base(context)
        {
            Assortment = context.Assortment;
        }
    }
}
