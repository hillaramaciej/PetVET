
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository
{
    public interface IReservationServiceRepository : IRepository<ReservationService>
    {
      //  IEnumerable<Assortment> Search(string search);

      // public IEnumerable<Customer> FindAndMap(Expression<Func<Customer, bool>> predicate,)
       
    }
}
