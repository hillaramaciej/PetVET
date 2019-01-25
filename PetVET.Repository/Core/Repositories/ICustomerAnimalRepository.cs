using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetVET.Repository
{
    
    public interface ICustomerAnimalRepository : IRepository<CustomerAnimal>
    {
        //IEnumerable<CustomerAnimals> Search(string search);

        // public IEnumerable<Customer> FindAndMap(Expression<Func<Customer, bool>> predicate,)

    }
}
