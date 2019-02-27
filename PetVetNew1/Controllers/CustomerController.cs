using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Database.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Repository;

namespace PetVetNew.Controllers
{
    [Authorize]
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


        [Route("customer/CustomersList")]
        public IActionResult CustomersList()
        {

            return View();
        }


        [Route("Customer/CustomerProfile/{id}")]
        public IActionResult CustomerProfile(int id)
        {
            Customer result = _IUnitOfWork.Customer.GetByID(id);

            var DTO = _mapper.Map<Customer, CustomerViewModel>(result);

            return View(DTO);
        }

    }
}