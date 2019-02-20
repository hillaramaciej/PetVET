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
    class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private DbSet<Customer> Customer;
        public CustomerRepository(DBVETContext context) : base(context)
        {
            Customer = context.Customer;
        }


        public IEnumerable<Customer> Search(string search, int page, int step)
        {

            var p = (page - 1) * step;

            return Customer.Where(x => x.CustPhone.Contains(search)
                                    || x.CustMail.Contains(search)
                                    || (x.CustLastname).Contains(search)
                                    || x.CustFirstname.Contains(search)).Skip(p).Take(step);
        }


        public int SearchCount(string search, int page, int step)
        {

            return Customer.Where(x => x.CustPhone.Contains(search)
                                    || x.CustMail.Contains(search)
                                    || (x.CustLastname).Contains(search)
                                    || x.CustFirstname.Contains(search)).Count();
        }

       
    }
}
