using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public interface ICreateOrganization
    {
        Task<bool> Create(string mail, int licenseCount);
    }
}
