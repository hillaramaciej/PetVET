using Microsoft.AspNetCore.Identity;
using PetVET.Models;
using PetVET.Models.Enums;
using PetVET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services.User
{
    public class UserOperation : IUserOperation
    {
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;
        private IUnitOfWork _unitOfWork;
        private IEmailSender _emailSender;

        public UserOperation(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signManager,
                                  IUnitOfWork unitOfWork,
                                  IEmailSender emailSender)
        {
            _userManager = userManager;
            _signManager = signManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        async public Task<bool> Create(ApplicationUser newUser, UserRoles role, System.Security.Claims.ClaimsPrincipal user)
        {

            var userToCreate = await _userManager.FindByEmailAsync(newUser.Email);
            if (userToCreate != null)
                return false;

            ApplicationUser currentUser = await _userManager.GetUserAsync(user);
                        
            try
            {                
                 userToCreate = new ApplicationUser { Email = newUser.Email,
                    UserName =  newUser.FirstName +" " + newUser.LastName,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    LicenseCount = 1,
                    OrganizationId = currentUser.OrganizationId
                };
                var result = await _userManager.CreateAsync(userToCreate, CreateRandomPassword());


                if (result.Succeeded)
                {
                    userToCreate = await _userManager.FindByEmailAsync(userToCreate.Email);
                    await _userManager.AddToRoleAsync(userToCreate, role.ToString());

                    await _emailSender.SendEmailConfirmationAsync(userToCreate.Email, "https://localhost:44343/Account/Login");

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


        public void Delete(string userMail)
        {
            throw new NotImplementedException();
        }

        public void AddClaims(string userMail, string claimsName, string clamesValue)
        {
            throw new NotImplementedException();
        }

        public void AddRole(string userMail, string RoleName)
        {
            throw new NotImplementedException();
        }


        string CreateRandomPassword()
        {
            return "NoweHasło!9";
        }


    }
}
