using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Database.Models;
using PetVET.Infrastructure;
using PetVET.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    [ModelStateValidationFilter]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        IApplicationUserAccesor _applicationUserAccesor;
        public CustomerApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper,
                                     IApplicationUserAccesor applicationUserAccesor)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _applicationUserAccesor = applicationUserAccesor;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string email = HttpContext.User?.Identity.Name;

            var tt = _applicationUserAccesor.Get();
            tt.FirstName = "asdadas";

            Customer result = _IUnitOfWork.Customer.GetByID(id);

            if (result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(_mapper.Map<Customer, CustomerViewModel>(result));
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            string email = HttpContext.User?.Identity.Name;

            Customer c = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);           
            try
            {             
                if (_IUnitOfWork.Customer.Find(x => x.CustMail == customerViewModel.CustMail).FirstOrDefault() != null)
                {
                    return new BadRequestObjectResult($"Klient o podanym email : {customerViewModel.CustMail}, istnieje juz w bazie klientów");
                }

                _IUnitOfWork.Customer.Add(c);
                _IUnitOfWork.Complete();

                customerViewModel.Rowid = _IUnitOfWork.Customer
                                            .Find(x => x.CustMail == customerViewModel.CustMail
                                            || x.CustPhone == customerViewModel.CustPhone).First().Rowid;
            }  
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }
            catch (Exception ex)
            {
                var y = "";
            }

            return CreatedAtAction("Get", new { userID = customerViewModel.Rowid });         
        }

        public async Task<IActionResult> GetAll()
        {
            var contactList = await _IUnitOfWork.Customer.FindAsync(x => x.Rowid > 0);
            return Ok(contactList);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("ss")]        
        public IActionResult ss()
        {
            return Ok("adadsadaD");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ss")]
        public IActionResult sss()
        {
            return Ok("adadsadaD");
        }


        [HttpPost("search")]
        //[ValidateAntiForgeryToken]
        public IActionResult Search([FromBody]CustomerQuickSearchcsDTO search)
        {           
            IEnumerable<Customer> result = null;
           
            int count = 0;
            try
            {
                count = _IUnitOfWork.Customer.SearchCount(search.Search, search.Page, search.Step);               
                result = _IUnitOfWork.Customer.Search(search.Search, search.Page, search.Step);               


            }
            catch (Exception ex)
            {
                //return NoContent();
                throw new Exception("Przepraszamy, proszę sprubować ponownie!");
            }
            if (result == null)
                return Ok(new List<CustomerViewModel>());

            IEnumerable<CustomerViewModel> CustomerViewModel = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(result.ToList());

            CustomerQuickSearchResultDTO DTO = new CustomerQuickSearchResultDTO()
            {
                Result = CustomerViewModel,
                Count = count,
                PagesNumber = count % search.Step == 0 ? count/ search.Step : count / search.Step + 1
            };

            return Ok(DTO);
       }
    }
}
