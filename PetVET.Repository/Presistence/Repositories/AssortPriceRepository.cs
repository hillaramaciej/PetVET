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
    class AssortPriceRepository : Repository<AssortPrice>, IAssortPriceRepository
    {
        private DbSet<AssortPrice> AssortPrice;
        public AssortPriceRepository(DBVETContext context) : base(context)
        {
            AssortPrice = context.AssortPrice;
        }


 

    }
}
