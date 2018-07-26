using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.CustomerViewModel;

namespace PetVET.Controllers
{
    public class CustomerController : Controller
    {
        [Route("Customer")]
        public IActionResult AddCustomer()
        {
            CustomerViewModel vm = new CustomerViewModel();          

            return View(vm);
        }   
    }
}