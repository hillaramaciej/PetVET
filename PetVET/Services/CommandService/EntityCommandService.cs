using Microsoft.EntityFrameworkCore;
using PetVET.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository.Core
{
    public class EntityCommandService<EntityIn, EntityOut, Error> :
        IEntityCommandService<EntityIn, EntityOut, Error>
        where EntityIn : IViewModel
        where EntityOut : IViewModel
        where Error : IErrorViewModel
    {

        DbContext _context;
        IStoreProcedureParser<EntityIn> _storeProcedureParser;

        public EntityCommandService(DbContext context, IStoreProcedureParser<EntityIn> storeProcedureParser)
        {
            _context = context;
            _storeProcedureParser = storeProcedureParser;
        }

        public async Task<ProcedureResult<EntityOut, Error>> ExecuteStoredProc(string storedProcName, EntityIn viewModel)
        {
            var paramiters = _storeProcedureParser.GetCommandParamiters(viewModel);
            var procedure = LoadStoredProc(storedProcName);
            WithSqlParams(procedure, paramiters);

            return await ExecuteStoredProc(procedure); ;
        }


        public DbCommand LoadStoredProc(string storedProcName)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandTimeout = 30;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }


        public void  WithSqlParams(DbCommand cmd, Dictionary<string,object> paramiters)
        {
            foreach (var param in paramiters)
            {
                WithSqlParam(cmd, param.Key, param.Value);
            }           
        }

        public void  WithSqlParam(DbCommand cmd, string paramName, object paramValue)
        {
            if (string.IsNullOrEmpty(cmd.CommandText))
                throw new InvalidOperationException(
                  "Call LoadStoredProc before using this method");
            var param = cmd.CreateParameter();
            param.ParameterName = "@" + paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
           
        }

        private  List<EntityOut> MapToList<EntityOut>(DbDataReader dr)
        {
            var objList = new List<EntityOut>();
            var props = typeof(EntityOut).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
              .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
              .ToDictionary(key => key.ColumnName.ToLower());

            if (colMapping.Count() > 0)
            {

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EntityOut obj = Activator.CreateInstance<EntityOut>();
                        foreach (var prop in props)
                        {
                            var val =
                              dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                        objList.Add(obj);
                    }
                }
            }
            return   objList.Count > 0 ? objList : null; 
        }

         private  Error MapToListError<Error>(DbDataReader dr)
        {
            var objList = new List<Error>();
            var props = typeof(Error).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
              .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
              .ToDictionary(key => key.ColumnName.ToLower());

            //if (colMapping.Count() > 0)
            //{

            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
                        Error obj = Activator.CreateInstance<Error>();
                        foreach (var prop in props)
                        {
                            //var val =
                            //  dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                prop.SetValue(obj, 1);// val == DBNull.Value ? null : val);
                        }
                        objList.Add(obj);
            //        }
            //    }
            //}
            return objList.FirstOrDefault();
        }

        public async Task<ProcedureResult<EntityOut,Error>> ExecuteStoredProc(DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        Error error =  default(Error);
                        List<EntityOut> entityOut = MapToList<EntityOut>(reader);

                       if(entityOut == null)
                        {
                            error = MapToListError<Error>(reader);                           
                        }

                        ProcedureResult<EntityOut, Error> result = new ProcedureResult<EntityOut, Error>()
                        {
                            Result = entityOut ?? null,
                            _Error = error != null ? error : default(Error),
                        };
                        return result;
                    }
                }
                catch (Exception e)
                {
                    throw (e);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void ff()
        {

        }

    
        // public interface await Task<List<T>> ExecuteStoredProc<T>(this DbCommand command)
    }
}
