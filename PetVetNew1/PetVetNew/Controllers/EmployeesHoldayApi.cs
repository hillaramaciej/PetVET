﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetVET.Database.Models;
using PetVET.Infrastructure;
using PetVET.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Models.EmployeesViewModels;
using PetVET.Repository;
using PetVET.Services.User;
using PetVetNew.Models.OpenHoursViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    [Authorize]
    //[ModelStateValidationFilter]
    [Route("api/[controller]")]
    public class EmployeesHoldayApiController : Controller
    {
        
        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        IApplicationUserAccesor _ApplicationUserAccesor;

        public EmployeesHoldayApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper,
                                     IUserOperation userOperation,
                                     IApplicationUserAccesor ApplicationUserAccesor)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _ApplicationUserAccesor = ApplicationUserAccesor;
        }

       // GET: api/<controller>
        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public IActionResult GetALL()
        {

            IEnumerable<HolidayDTO> holidayDTOList = new List<HolidayDTO>()
            {
                new HolidayDTO()
                {
                    Id = 1,
                    DateFrom = new DateTime(2012,2,4),
                    DateTo = new DateTime(2012,2,4),
                    HolidayName = "Maj",
                    Month = PetVetNew.Models.Enums.Month.Maj

                 },
                    new HolidayDTO()
                {
                    Id = 2,
                    DateFrom = new DateTime(2012,2,4),
                    DateTo = new DateTime(2012,2,4),
                    HolidayName = "Czerwiec",
                    Month = PetVetNew.Models.Enums.Month.Czerwiec

                 },
                      new HolidayDTO()
                      {
                    Id = 3,
                    DateFrom = new DateTime(2012,2,4),
                    DateTo = new DateTime(2012,2,4),
                    HolidayName = "Styczeń",
                    Month = PetVetNew.Models.Enums.Month.Styczeń

                 },
            };

            return Ok(holidayDTOList);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var ttt = _ApplicationUserAccesor.Get();
            Employee result = _IUnitOfWork.Employee.GetByID(id);

            if (result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(result);
        }




       // POST api/<controller>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ModelStateValidationFilter]
        public IActionResult Post([FromBody]HolidayDTO employeesViewModel)
        {
            int id = 0;

           // Employee c = _mapper.Map<HolidaysDTO, EmployeeHoliday>(employeesViewModel);
            try
            {


                return new BadRequestObjectResult($"Klient o podanym email : , istnieje juz w bazie klientów");





                //return new ObjectResult($"Klient o podanym email : {employeesViewModel.Email}, istnieje juz w bazie klientów");

                //if (_IUnitOfWork.Employee.Find(x => x.EmplEmail == employeesViewModel.Email).FirstOrDefault() != null)
                //{
                //    return new ObjectResult($"Klient o podanym email : {employeesViewModel.Email}, istnieje juz w bazie klientów");
                //}

                // _IUnitOfWork.Employee.Add(c);

                //if (!_userOperation.Create(new ApplicationUser(), Models.Enums.UserRoles.WETERYNARZ, User).Result)
                //{
                //    _IUnitOfWork.Employee.Remove(c);

                //}
                // _IUnitOfWork.Complete();

                //id = _IUnitOfWork.Employee.Find(x => x.EmplEmail == employeesViewModel.Email).First().Rowid;
            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }

            return CreatedAtAction("Get", new { userID = id });
        }

        //public async Task<IActionResult> GetAll()
        //{
        //    var contactList = await _IUnitOfWork.Employee.FindAsync(x => x.Rowid > 0);
        //    return Ok(contactList);
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        //[HttpPost("search")]
        //public IActionResult Search([FromBody]CustomerQuickSearchcsDTO search)
        //{
        //    IEnumerable<Customer> result = null;
        //    int count = 0;
        //    try
        //    {
        //        count = _IUnitOfWork.Customer.SearchCount(search.Search, search.Page, search.Step);
        //        result = _IUnitOfWork.Customer.Search(search.Search, search.Page, search.Step);


        //    }
        //    catch (Exception ex)
        //    {
        //        //return NoContent();
        //        throw new Exception("Przepraszamy, proszę sprubować ponownie!");
        //    }
        //    if (result == null)
        //        return Ok(new List<CustomerViewModel>());

        //    IEnumerable<CustomerViewModel> CustomerViewModel = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(result.ToList());

        //    CustomerQuickSearchResultDTO DTO = new CustomerQuickSearchResultDTO()
        //    {
        //        Result = CustomerViewModel,
        //        Count = count,
        //        PagesNumber = count % search.Step == 0 ? count / search.Step : count / search.Step + 1
        //    };

        //    return Ok(DTO);
        //}
    }
}
