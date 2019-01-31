using Microsoft.AspNetCore.Identity;
using PetVET.Data;
using PetVET.Models;
using PetVET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public class CreateOrganization : ICreateOrganization
    {

        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;
        private IUnitOfWork _unitOfWork;

        public CreateOrganization(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signManager,
                                  IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signManager = signManager;
            _unitOfWork = unitOfWork;
        }

        async public Task<bool> Create(string mail, int licenseCount)
        {
            var user = await _userManager.FindByEmailAsync(mail);
            if (user != null)            
                return false;            

            try
            {               
                int LastOrganizatioId = _userManager.Users.ToList().Max(x => x.OrganizationId);
                user = new ApplicationUser { Email = mail, UserName = mail, LicenseCount = licenseCount, OrganizationId = LastOrganizatioId + 1 };
                var result = await _userManager.CreateAsync(user, CreateRandomPassword());


                if (result.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(mail);
                    await _userManager.AddToRoleAsync(user, "Manager");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        string CreateRandomPassword()
        {
            return "NoweHasło!9";
        }


    }
}
