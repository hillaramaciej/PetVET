﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.AboutUsViewModels;
using PetVET.Models.SuperAdmin;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class SuperAdminController : Controller
    {
        [Authorize(Roles = "SuperAdmin")]
        [Route("AddOrganization")]
        public IActionResult AddOrganization()
        {
            AddOrganizationViewModel vm = new AddOrganizationViewModel();

            return View(vm);
        }
    }
}
