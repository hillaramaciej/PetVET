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
using PetVET.Models.CustomerViewModels;
using PetVET.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
   // [ServiceFilter(typeof(ModelStateValidationFilter),Order =3)]
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        PetVetDbContext _PetVetDbContext;

        public CustomerApiController(IUnitOfWork IUnitOfWork, IMapper mapper, PetVetDbContext petVetDbContext)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _PetVetDbContext = petVetDbContext;
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
            Customer result =  _IUnitOfWork.Customer.GetByID(id);

            if(result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            Customer c = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);
            
            try
            {
                if(_IUnitOfWork.Customer.Find(x=>x.CusEmail == customerViewModel.Mail).FirstOrDefault() != null)
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
                throw;
            }

            return CreatedAtAction("Get", new { userID = customerViewModel.UserID });
            //return Ok(Json(JsonConvert.SerializeObject(customerViewModel)));
        }

        public async Task<IActionResult> GetAll()
        {
            var contactList = await _IUnitOfWork.Customer.FindAsync(x=> x.Rowid > 0);
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
    }
}
