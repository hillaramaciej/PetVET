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
using PetVET.Repository.Core;
using PetVET.Services.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    //[Authorize]
    //[ModelStateValidationFilter]
    [Route("api/[controller]")]
    public class EmployeesApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        IUserOperation _userOperation;
        IApplicationUserAccesor _ApplicationUserAccesor;

        public EmployeesApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper,
                                     IUserOperation userOperation,
                                     IApplicationUserAccesor ApplicationUserAccesor)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _userOperation = userOperation;
            _ApplicationUserAccesor = ApplicationUserAccesor;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var tt = _ApplicationUserAccesor.Get();
            tt.FirstName = "asdadas";

            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var ttt = _ApplicationUserAccesor.Get();
            Vet result = _IUnitOfWork.Vet.GetByID(id);

            if (result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        //[ModelStateValidationFilter]
        public IActionResult Post([FromBody]EmployeesViewModel employeesViewModel)
        {
            int id = 0;
           
            Vet c = _mapper.Map<EmployeesViewModel, Vet>(employeesViewModel);
            try
            {

                if (_IUnitOfWork.Vet.Find(x => x.VetEmail == employeesViewModel.Email).FirstOrDefault() != null)
                {
                    return new ObjectResult($"Klient o podanym email : {employeesViewModel.Email}, istnieje juz w bazie klientów");
                }

                _IUnitOfWork.Vet.Add(c);
                
                if (!_userOperation.Create(new ApplicationUser(), Models.Enums.UserRoles.WETERYNARZ, User).Result)
                {
                    _IUnitOfWork.Vet.Remove(c);
                    
                }
                _IUnitOfWork.Complete();

                id = _IUnitOfWork.Vet.Find(x => x.VetEmail == employeesViewModel.Email).First().Rowid;
            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }

            return CreatedAtAction("Get", new { userID = id });
        }

        public async Task<IActionResult> GetAll()
        {
            var contactList = await _IUnitOfWork.Vet.FindAsync(x => x.Rowid > 0);
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
        [HttpPost("search")]
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
                PagesNumber = count % search.Step == 0 ? count / search.Step : count / search.Step + 1
            };

            return Ok(DTO);
        }
    }
}
