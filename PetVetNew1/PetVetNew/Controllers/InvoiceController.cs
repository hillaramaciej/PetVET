using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.InvoiceViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class InvoiceController : Controller
    {
        [Authorize]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            InvoiceViewModel vm = new InvoiceViewModel();

            return View(vm);
        }
    }
}
