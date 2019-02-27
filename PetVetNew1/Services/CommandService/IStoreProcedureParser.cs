using PetVET.Models;
using PetVET.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public interface  IStoreProcedureParser<T> where T : IViewModel
    {
        KeyValuePair<string, IEnumerable<object>> GetCommandParamiters(T model,string procedureName);
        Dictionary<string, object> GetCommandParamiters(T model);
    }
}
