using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Database.Models;
using PetVET.Models;
using PetVET.Models._Common;
using PetVET.Models.CustomerViewModels;
using PetVET.Models.ServiceViewModels;
using PetVET.Models.SuperAdmin;
using PetVET.Repository;
using PetVET.Repository.Core;
using PetVET.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    //[Authorize(Roles ="SuperAdmin")]   
    //[ModelStateValidationFilter]
    [Route("api/[controller]")]
    public class SuperAdminApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        ICreateOrganization _createOrganization;
        public SuperAdminApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper, ICreateOrganization createOrganization)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _createOrganization = createOrganization;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {           
            return Ok();
        }

        // POST api/<controller>
        [HttpPost]
        async public Task<IActionResult> Post([FromBody]AddOrganizationViewModel serviceViewModel)
        {
            if (!ModelState.IsValid)
                return null;    //do obczajenia kiedy co powinien zwracać
            try
            {
              var result = await _createOrganization.Create(serviceViewModel.Mail, serviceViewModel.LicenseCount);

                if (!result)
                {
                    return new BadRequestObjectResult("nie udało sie dodać nowej organizacji prosimy spróbawać ponowanie");
                }

            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }
            catch(Exception ex)
            {
                throw new Exception("Internal servier error, please conntact with Administration");
            }

            return Ok("Poprawnie dodano nowe konto");
        }

        public IActionResult GetAll()
        {           
            return Ok();
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
