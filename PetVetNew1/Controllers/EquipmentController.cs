using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.EquipmentViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class EquipmentController : Controller
    {
        [Authorize]
        [Route("Equipment")]
        public IActionResult Equipment()
        {
            EquipmentViewModel vm = new EquipmentViewModel();

            return View(vm);
        }
    }
}
