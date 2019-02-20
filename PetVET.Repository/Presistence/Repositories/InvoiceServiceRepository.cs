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
    class InvoiceServiceRepository : Repository<InvoiceService>, IInvoiceServiceRepository
    {
        private DbSet<InvoiceService> InvoiceService;
        public InvoiceServiceRepository(DBVETContext context) : base(context)
        {
            InvoiceService = context.InvoiceService;
        }


    }
}
