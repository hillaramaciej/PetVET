
using Microsoft.EntityFrameworkCore;
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetVetDbContext _context;

        public ICustomerRepository Customer { get; set; }
        public IAssortmentRepository Assortment { get; set; }

        PetVetDbContext IUnitOfWork.Context => _context;

        public UnitOfWork(PetVetDbContext context)
        {            
            _context = context;
            Customer = new CustomerRepository(context);
            Assortment = new AssortmentRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
