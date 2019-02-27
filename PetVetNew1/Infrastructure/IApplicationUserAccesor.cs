using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetVET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Infrastructure
{
    public interface IApplicationUserAccesor : IActionContextAccessor
    {
         ApplicationUser Get();
    }
}
