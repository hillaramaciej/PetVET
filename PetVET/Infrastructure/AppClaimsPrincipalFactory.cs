using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PetVET.Models;
using PetVET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetVET.Infrastructure
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IUnitOfWork unitOfWork)
        : base(userManager, roleManager, optionsAccessor)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            //_unitOfWork.

            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        new Claim(ClaimTypes.GivenName, user.FirstName)
    });
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
         new Claim(ClaimTypes.Surname, user.LastName),
    });
            }

            return principal;


        }
    }
}
