using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetVET.Models.CustomerViewModels;
using PetVET.Repository;

namespace PetVET.Controllers
{
    public class CustomerController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;


        public CustomerController(IUnitOfWork IUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
        }

        [Route("Customer")]
        public IActionResult Customer()

        {          
            return View(new CustomerViewModel());
        }


       
        public IActionResult CustomersList()
        {
            return View();
        }
    }
}