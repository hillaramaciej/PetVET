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
    class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        private DbSet<Animal> Animal;
        public AnimalRepository(DBVETContext context) : base(context)
        {
            Animal = context.Animal;
        }



    }
}
