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
    class CustomerAnimalRepository : Repository<CustomerAnimal>, ICustomerAnimalRepository
    {
        private DbSet<CustomerAnimal> CustomerAnimal;
        public CustomerAnimalRepository(DBVETContext context) : base(context)
        {
            CustomerAnimal = context.CustomerAnimal;
        }



  
    }
}
