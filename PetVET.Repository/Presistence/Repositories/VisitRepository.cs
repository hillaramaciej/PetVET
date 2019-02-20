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
    class VisitRepository : Repository<Visit>, IVisitRepository
    {
        private DbSet<Visit> Visit;
        public VisitRepository(DBVETContext context) : base(context)
        {
            Visit = context.Visit;
        }

    }
}
