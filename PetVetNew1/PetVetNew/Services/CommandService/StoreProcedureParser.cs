using PetVET.Models;
using PetVET.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public class StoreProcedureParser<T> : IStoreProcedureParser<T> where T : IViewModel
    {
        public KeyValuePair<string, IEnumerable<object>> GetCommandParamiters(T model, string procedureName)
        {
            string query = procedureName;
            List<object> paramiters = new List<object>();

            Type type = model.GetType();

            foreach (PropertyInfo prop in type.GetProperties().Where(x=>x.Module.Name != "AutoMapper.dll"))
            {

                var value = prop.GetValue(model);
                var name = prop.Name;
                query += " @" + name + ",";
                paramiters.Add(value);
            }

            return new KeyValuePair<string, IEnumerable<object>>(query, paramiters);
        }

        public Dictionary<string, object> GetCommandParamiters(T model)
        {
            Dictionary<string, object> paramiters = new Dictionary<string, object>();          

            Type type = model.GetType();

            foreach (PropertyInfo prop in type.GetProperties().Where(x => x.Module.Name != "AutoMapper.dll"))
            {
                var value = prop.GetValue(model);
                var name = prop.Name;               
                paramiters.Add(name,value);            }

            return paramiters;
        }
    }
}
