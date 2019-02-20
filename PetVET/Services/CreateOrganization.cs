using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        private IEmailSender _emailSender;
        private IActionContextAccessor _actionContextAccessor;
        public CreateOrganization(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signManager,
                                  IUnitOfWork unitOfWork,
                                  IEmailSender emailSender,
                                  IActionContextAccessor actionContextAccessor)
        {
            _userManager = userManager;
            _signManager = signManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _actionContextAccessor = actionContextAccessor;
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

                    var host = _actionContextAccessor.ActionContext.HttpContext.Request.Host.Value;
                    var scheme = _actionContextAccessor.ActionContext.HttpContext.Request.Scheme;

                    await _emailSender.SendEmailConfirmationAsync(mail, $"{scheme}://{host}/Manage/ChangePassword");

                    return true;
                }
                else
                {
                    user = await _userManager.FindByEmailAsync(mail);
                    if (user != null)
                        await _userManager.DeleteAsync(user);
                    return false;
                }

            }
            catch (Exception ex)
            {
                user = await _userManager.FindByEmailAsync(mail);
                if (user != null)
                    await _userManager.DeleteAsync(user);
                return false;
            }
        }

        string CreateRandomPassword()
        {
            return "NoweHasło!9";
        }


    }
}
