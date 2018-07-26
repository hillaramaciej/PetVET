
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


        public UnitOfWork(PetVetDbContext context)
        {
            _context = context;
            Customer = new CustomerRepository(context);
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
