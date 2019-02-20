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
    class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private DbSet<Assortment> Invoice;
        public InvoiceRepository(DBVETContext context) : base(context)
        {
            Invoice = context.Assortment;
        }

    }
}
