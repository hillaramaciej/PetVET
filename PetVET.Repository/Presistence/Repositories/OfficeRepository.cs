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
    class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        private DbSet<Office> Office;
        public OfficeRepository(DBVETContext context) : base(context)
        {
            Office = context.Office;
        }
    }
}
