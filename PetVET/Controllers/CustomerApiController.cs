using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetVET.Database.Models;
using PetVET.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Repository;
using PetVET.Repository.Core;
using PetVET.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    // [ServiceFilter(typeof(ModelStateValidationFilter),Order =3)]
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        IEntityCommandService<CustomerViewModel, Test, ErrorViewModel> _entityCommandService;

        public CustomerApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper,
                                     IEntityCommandService<CustomerViewModel, Test, ErrorViewModel> customerViewModel)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _entityCommandService = customerViewModel;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}",Name ="Get")]
        public IActionResult Get(int id)
        {
            Customer result = _IUnitOfWork.Customer.GetByID(id);

            if (result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
           // ProcedureResult<Test, ErrorViewModel> result =  _entityCommandService.ExecuteStoredProc("Test", customerViewModel).Result;

            Customer c = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);           
            try
            {
                if (_IUnitOfWork.Customer.Find(x => x.CusEmail == customerViewModel.Mail).FirstOrDefault() != null)
                {
                    return new ObjectResult($"Klient o podanym email : {customerViewModel.Mail}, istnieje juz w bazie klientów");
                }

                _IUnitOfWork.Customer.Add(c);
                _IUnitOfWork.Complete();

                customerViewModel.UserID = _IUnitOfWork.Customer
                                            .Find(x => x.CusEmail == customerViewModel.Mail
                                            || x.CusPhone == customerViewModel.PhonNumber).First().Rowid;
            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }

            return CreatedAtAction("Get", new { userID = customerViewModel.UserID });         
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
        [HttpPost("search")]
        public IActionResult Search([FromBody]CustomerQuickSearchcsDTO search)
        {           
            IEnumerable<Customer> result = null;
            
            try
            {
                result = _IUnitOfWork.Customer.Search(search.Search);
               
            }
            catch (Exception ex)
            {
                throw new Exception("Przepraszamy, proszę sprubować ponownie!");
            }
            if (result == null)
                return Ok(new List<CustomerViewModel>());

            var DTO = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(result.ToList());

            return Ok(DTO);
       }
    }
}
