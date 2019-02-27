using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetVET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Infrastructure
{
    public class ApplicationUserAccesor : ActionContextAccessor, IApplicationUserAccesor
    {
        private UserManager<ApplicationUser> _userManager;

        public ApplicationUserAccesor(UserManager<ApplicationUser> userManager) : base()
        {
            _userManager = userManager;
        }        

        public ApplicationUser Get()
        {
            return  _userManager.GetUserAsync(base.ActionContext.HttpContext.User).Result;
        }
    }
}
