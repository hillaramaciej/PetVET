using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.ServiceViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class ServiceController : Controller
    {
        [Authorize]
        [Route("Service")]
        public IActionResult AddService()
        {
            ServiceViewModel vm = new ServiceViewModel();

            return View(vm);
        }
    }
}
