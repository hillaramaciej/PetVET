
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IAssortmentRepository Assortment { get; }

        PetVetDbContext Context { get; }

        int Complete();
    }
}
