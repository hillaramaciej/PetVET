
using PetVET.Models;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services.User
{
    public interface IUserOperation
    {

        Task<bool> Create(ApplicationUser newUser, UserRoles role, System.Security.Claims.ClaimsPrincipal user);

        void Delete(string userMail);

        void AddClaims(string userMail, string claimsName, string clamesValue);

        void AddRole(string userMail, string RoleName);
      
    }
}
