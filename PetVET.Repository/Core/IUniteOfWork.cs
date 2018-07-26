

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
        
        int Complete();
    }
}
