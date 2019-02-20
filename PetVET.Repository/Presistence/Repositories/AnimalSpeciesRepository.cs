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
    class AnimalSpeciesRepository : Repository<AnimalSpecies>, IAnimalSpeciesRepository
    {
        private DbSet<AnimalSpecies> AnimalSpecies;
        public AnimalSpeciesRepository(DBVETContext context) : base(context)
        {
            AnimalSpecies = context.AnimalSpecies;
        }

    }
}
