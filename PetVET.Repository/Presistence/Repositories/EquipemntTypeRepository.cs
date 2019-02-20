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
    class EquipemntTypeRepository : Repository<EquipemntType>, IEquipemntTypeRepository
    {
        private DbSet<EquipemntType> EquipemntType;
        public EquipemntTypeRepository(DBVETContext context) : base(context)
        {
            EquipemntType = context.EquipemntType;
        }


      
    }
}
