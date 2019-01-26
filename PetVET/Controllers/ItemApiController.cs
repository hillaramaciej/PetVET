using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetVET.Database.Models;
using PetVET.Models.ItemViewModels;
using PetVET.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetVET.Controllers
{
    // [ServiceFilter(typeof(ModelStateValidationFilter),Order =3)]
    [Authorize]
    [Route("api/[controller]")]
    public class ItemApiController : Controller
    {

        IUnitOfWork _IUnitOfWork;
        IMapper _mapper;
        //IEntityCommandService<ItemViewModel, Test, ErrorViewModel> _entityCommandService;

        public ItemApiController(IUnitOfWork IUnitOfWork,
                                     IMapper mapper)
                                     //IEntityCommandService<ItemViewModel, Test, ErrorViewModel> itemViewModel)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
           // _entityCommandService = itemViewModel;
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
            Assortment result = _IUnitOfWork.Assortment.GetByID(id);

            if (result == null)
            {
                return NotFound("Produkt nie istnieje w bazie danych");
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ItemViewModel itemViewModel)
        {
           // ProcedureResult<Test, ErrorViewModel> result =  _entityCommandService.ExecuteStoredProc("Test", itemViewModel).Result;
           

            try
            {
                OfficeDepartment od = _IUnitOfWork.OfficeDepartment.Find(x => x.Rowid == 1).First();

                Assortment c = _mapper.Map<ItemViewModel, Assortment>(itemViewModel);
                
                if (_IUnitOfWork.Assortment.Find(x => x.AssDesc == itemViewModel.ItemName).FirstOrDefault() != null)
                {
                    return new ObjectResult($"Klient o podanym email : {itemViewModel.ItemName}, istnieje juz w bazie klientów");
                }

                od.Assortment.Add(c);

                //_IUnitOfWork.Assortment(c);
                _IUnitOfWork.Complete();

                itemViewModel.ItemID = _IUnitOfWork.Assortment
                                            .Find(x => x.AssDesc == itemViewModel.ItemName).First().Rowid;
                                            
            }
            catch (SqlException exc)
            {
                throw new Exception("Internal servier error");
            }
            catch (Exception ex)
            {
                var T  = "";
            }

           

            return CreatedAtAction("Get", new { id = itemViewModel.ItemID });         
        }

        public async Task<IActionResult> GetAll()
        {
            var contactList = await _IUnitOfWork.Assortment.FindAsync(x => x.Rowid > 0);
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
       // [HttpPost("search")]
       // public IActionResult Search([FromBody]ItemQuickSearchcsDTO search)
       // {           
       //     IEnumerable<Assortment> result = null;
            
       //     try
       //     {
       //         result = _IUnitOfWork.Assortment.Search(search.Search);
               
       //     }
       //     catch (Exception ex)
       //     {
       //         //return NoContent();
       //         throw new Exception("Przepraszamy, proszę sprubować ponownie!");
       //     }
       //     if (result == null)
       //         return Ok(new List<ItemViewModel>());

       //     var DTO = _mapper.Map<IEnumerable<Assortment>, IEnumerable<ItemViewModel>>(result.ToList());

       //     return Ok(DTO);
       //}
    }
}
