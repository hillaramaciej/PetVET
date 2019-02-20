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
using PetVET.Repository;
using PetVET.Repository.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    //[Authorize]
    //[ModelStateValidationFilter]
    [Route("api/[controller]")]
    public class ServiceApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;

        public ServiceApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<Servic> dto = null;
            try
            {
                dto =  _IUnitOfWork.Servic.GetAll().ToList();
                var result = _mapper.Map<List<Servic>, List<DllDTO>>(dto);
                return Ok(result);
            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }
            catch (Exception ex)
            {
               
            }

            return NotFound("Klient nie istnieje w bazie danych");
            

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Servic result = _IUnitOfWork.Servic.GetByID(id);  //baza danych

            if (result == null)
            {
                return NotFound("Klient nie istnieje w bazie danych");
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ServiceViewModel serviceViewModel)
        {         
           // try
          //  {
                //    Servic c = _mapper.Map<ServiceViewModel, Servic>(serviceViewModel);           //baza danych 
                //    c.TreOdt = _IUnitOfWork.Office.Find(x => x.Rowid == 1).FirstOrDefault();
                //    c.TrePkwiuNavigation = _IUnitOfWork.PKWIUR.Find(x => x.PkwiuCode == "21.10.54.0").FirstOrDefault();



                //    if (_IUnitOfWork.Servic.Find(x => x.ServicDesc == serviceViewModel.ServiceName).FirstOrDefault() != null)     //baza danych
                //    {
                //        return new ObjectResult($"Usługa o podanej nazwie : {serviceViewModel.ServiceName}, istnieje juz w bazie usług");
                //    }

                //    _IUnitOfWork.Servic.Add(c);   //baza
                //    _IUnitOfWork.Complete();

                //    serviceViewModel.ServiceID = _IUnitOfWork.Servic
                //                                .Find(x => x.ServicDesc == serviceViewModel.ServiceName).First().Rowid;
                //}
                //catch (SqlException exc)
                //{
                //    throw new Exception("Internal servier error");
                //}
                //catch(Exception ex)
                //{
                //    var t = "";
                //}

                //return CreatedAtAction("Get", new { id = serviceViewModel.ServiceID });         

                return null;
        }

        public async Task<IActionResult> GetAll()
        {
            var contactList = await _IUnitOfWork.Servic.FindAsync(x => x.Rowid > 0);  //baza danych
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
