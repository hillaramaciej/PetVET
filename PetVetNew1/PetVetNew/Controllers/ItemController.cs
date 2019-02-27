using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.ItemViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class ItemController : Controller
    {
        [Authorize]
        [Route("Item")]
        public IActionResult AddItem()
        {
            ItemViewModel vm = new ItemViewModel();

            return View(vm);
        }
    }
}
