using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.PetViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{

    [Authorize]
    public class PetController : Controller
    {
        [Route("Pet")]
        public IActionResult AddPet()
        {
            PetViewModel vm = new PetViewModel();

            return View(vm);
        }
    }
}
