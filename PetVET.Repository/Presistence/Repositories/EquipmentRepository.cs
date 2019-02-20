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
    class EquipmentRepository : Repository<Equipemnt>, IEquipmentRepository
    {
        private DbSet<Equipemnt> Equipment;
        public EquipmentRepository(DBVETContext context) : base(context)
        {
            Equipment = context.Equipemnt;
        }

    }
}
