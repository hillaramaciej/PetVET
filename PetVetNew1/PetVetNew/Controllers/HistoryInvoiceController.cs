using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.HistoryInvoiceViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    public class HistoryInvoiceController : Controller
    {
        [Authorize]
        [Route("HistoryInvoice")]
        public IActionResult HistoryInvoice()
        {
            HistoryInvoiceViewModel vm = new HistoryInvoiceViewModel();

            return View(vm);
        }
    }
}
