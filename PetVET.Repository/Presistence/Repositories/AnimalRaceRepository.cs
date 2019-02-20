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
    class AnimalRaceRepository : Repository<AnimalRace>, IAnimalRaceRepository
    {
        private DbSet<AnimalRace> AnimalRace;
        public AnimalRaceRepository(DBVETContext context) : base(context)
        {
            AnimalRace = context.AnimalRace;
        }



    }
}
