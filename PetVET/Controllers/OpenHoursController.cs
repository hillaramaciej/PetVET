using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.OpenHoursViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class OpenHoursController : Controller
    {
        [Authorize]
        [Route("OpenHours")]
        public IActionResult OpenHours()
        {
            OpenHoursViewModel vm = new OpenHoursViewModel();

            return View(vm);
        }
    }
}
