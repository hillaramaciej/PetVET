using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.CategoryViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        [Route("Category")]
        public IActionResult Category()
        {
            CategoryViewModel vm = new CategoryViewModel();

            return View(vm);
        }
    }
}
