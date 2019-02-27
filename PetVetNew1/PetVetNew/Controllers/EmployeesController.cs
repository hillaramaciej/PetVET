using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.EmployeesViewModels;
using PetVET.Models.ServiceViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class EmployeesController : Controller
    {
        [Authorize]
        [Route("Employees")]
        public IActionResult Employees()
        {
            EmployeesViewModel vm = new EmployeesViewModel();

            return View(vm);
        }
    }
}
