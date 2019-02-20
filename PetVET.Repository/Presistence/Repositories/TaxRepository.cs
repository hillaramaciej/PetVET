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
    class TaxRepository : Repository<Tax>, ITaxRepository
    {
        private DbSet<Tax> Tax;
        public TaxRepository(DBVETContext context) : base(context)
        {
            Tax = context.Tax;
        }
      
    }
}
