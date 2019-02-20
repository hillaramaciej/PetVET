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
    class InvoiceAssortmentRepository : Repository<InvoiceAssortment>, IInvoiceAssortmentRepository
    {
        private DbSet<InvoiceAssortment> InvoiceAssortment;
        public InvoiceAssortmentRepository(DBVETContext context) : base(context)
        {
            InvoiceAssortment = context.InvoiceAssortment;
        }


      
    }
}
