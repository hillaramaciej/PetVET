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
        public InvoiceRepository(PetVetDbContext context) : base(context)
        {
            Invoice = context.Assortment; 
        }


        public PetVetDbContext GromContext
        {
            get
            {
                return Context as PetVetDbContext;
            }
        }

        //public void Add(Customer entity)
        //{
        //    Customer.Add(entity);
        //}

        //public void AddRange(IEnumerable<Customer> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        //{
        //    return Customer.Where(predicate);
        //}

        //public void Remove(Customer entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveRange(IEnumerable<Customer> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<Customer> IRepository<Customer>.GetAll()
        //{
        //    return Customer.Select(x => x);
        //}

        //Customer IRepository<Customer>.GetByID(int id)
        //{
        //  return Customer.Find(id);
        //}       

        //public Task<Customer> FindAsync(Expression<Func<Customer, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Customer> Search(string search)
        //{   
        //    return Customer.Where(x => x.CusPhone.Contains(search)
        //                            || x.CusEmail.Contains(search)
        //                            || (x.CusLastname).Contains(search)
        //                            || x.CusName.Contains(search));
        //}

        //public IEnumerable<Customer> FindAndMap(Expression<Func<Customer, bool>> predicate, object )
        //{
        //    throw new NotImplementedException();
        //}
    
    }
}
