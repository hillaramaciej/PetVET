using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.AboutUsViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class AboutUsController : Controller
    {
        [Authorize]
        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            AboutUsViewModel vm = new AboutUsViewModel();

            return View(vm); ;
        }
    }
}
