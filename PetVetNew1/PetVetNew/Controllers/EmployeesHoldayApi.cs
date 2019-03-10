using System;
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
    [ModelStateValidationFilter]
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
        //[HttpGet]
        ////[Route("api/[controller]/GetAll")]
        //public IActionResult Get()
        //{

        //    IEnumerable<HolidayDTO> holidayDTOList = new List<HolidayDTO>()
        //    {
        //        new HolidayDTO()
        //        {
        //            Id = 1,
        //            DateFrom = new DateTime(2012,2,4),
        //            DateTo = new DateTime(2012,2,4),
        //            HolidayName = "Maj",
        //            Month = PetVetNew.Models.Enums.Month.Maj

        //         },
        //            new HolidayDTO()
        //        {
        //            Id = 2,
        //            DateFrom = new DateTime(2012,2,4),
        //            DateTo = new DateTime(2012,2,4),
        //            HolidayName = "Czerwiec",
        //            Month = PetVetNew.Models.Enums.Month.Czerwiec

        //         },
        //              new HolidayDTO()
        //              {
        //            Id = 3,
        //            DateFrom = new DateTime(2012,2,4),
        //            DateTo = new DateTime(2012,2,4),
        //            HolidayName = "Styczeń",
        //            Month = PetVetNew.Models.Enums.Month.Styczeń

        //         },
        //    };

        //    return Ok(holidayDTOList);
       // }

        // GET api/<controller>/5
        [HttpGet("{month}")]
        public IActionResult Get(PetVetNew.Models.Enums.Month month)
        {

            IEnumerable<HolidayStringDTO> holidayDTOList = new List<HolidayStringDTO>()
            {
                new HolidayStringDTO()
                {
                    Id = 1,
                    DateFrom = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    DateTo = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    HolidayName = "swięto 1",
                    //Month = PetVetNew.Models.Enums.Month.Maj

                 },
                    new HolidayStringDTO()
                {
                    Id = 2,
                    DateFrom = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    DateTo = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    HolidayName = "swięto 2",
                   // Month = PetVetNew.Models.Enums.Month.Czerwiec

                 },
                      new HolidayStringDTO()
                      {
                    Id = 3,
                    DateFrom = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    DateTo = new DateTime(2012,2,4).ToString("yyyy-MM-dd"),
                    HolidayName = "swięto 3",
                    //Month = PetVetNew.Models.Enums.Month.Styczeń

                 },
            };

            return Ok(holidayDTOList);
        }




       // POST api/<controller>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ModelStateValidationFilter]
        public IActionResult Post([FromBody]HolidayDTO employeesViewModel)
        {
            int id = 0;
            //  return new BadRequestObjectResult($"Święto o podanej nazwie : '{employeesViewModel.HolidayName}', istnieje juz w kalendarzu");

            // Employee c = _mapper.Map<HolidaysDTO, EmployeeHoliday>(employeesViewModel);


            Random random = new Random();
            var i =  random.Next();

            try
            {
                HolidayStringDTO holidayStringDTO = new HolidayStringDTO()
                {
                    DateFrom = employeesViewModel.DateFrom.ToString("yyyy-MM-dd"),
                    DateTo = employeesViewModel.DateTo.ToString("yyyy-MM-dd"),
                    HolidayName = employeesViewModel.HolidayName,
                    Id = employeesViewModel.Id == 0 ? i : employeesViewModel.Id
                };



                return Ok(holidayStringDTO);





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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          //  return new BadRequestObjectResult($"Mamy Problem proszę spróbować jeszcze raz!!");
            return Ok(id);

        }
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
