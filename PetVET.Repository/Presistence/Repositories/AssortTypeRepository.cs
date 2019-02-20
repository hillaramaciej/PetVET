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
    class AssortTypeRepository : Repository<AssortType>, IAssortTypeRepository
    {
        private DbSet<AssortType> AssortType;
        public AssortTypeRepository(DBVETContext context) : base(context)
        {
            AssortType = context.AssortType;
        }


    }
}
