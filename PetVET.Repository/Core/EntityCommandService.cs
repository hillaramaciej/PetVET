//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace PetVET.Repository.Core
//{
//    public class EntityCommandService<T,E> : IEntityCommandService<T,E> where T : IViewModel  where E : IErrorViewModel
//    {

//        DbContext _context;

//        public EntityCommandService(DbContext context)
//        {
//            this._context = context;
//        }

//        ProcedureResult<T,E> IEntityCommandService<T,E>.ExecuteStoredProc(string storedProcName, T viewModel)
//        {
//            return null;
//        }

//        public DbCommand LoadStoredProc(DbContext context, string storedProcName)
//        {
//            var cmd = context.Database.GetDbConnection().CreateCommand();
//            cmd.CommandText = storedProcName;
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            return cmd;
//        }

//        public DbCommand WithSqlParam(DbCommand cmd, string paramName, object paramValue)
//        {
//            if (string.IsNullOrEmpty(cmd.CommandText))
//                throw new InvalidOperationException(
//                  "Call LoadStoredProc before using this method");
//            var param = cmd.CreateParameter();
//            param.ParameterName = paramName;
//            param.Value = paramValue;
//            cmd.Parameters.Add(param);
//            return cmd;
//        }

//        private  List<T> MapToList<T>(DbDataReader dr)
//        {
//            var objList = new List<T>();
//            var props = typeof(T).GetRuntimeProperties();

//            var colMapping = dr.GetColumnSchema()
//              .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
//              .ToDictionary(key => key.ColumnName.ToLower());

//            if (dr.HasRows)
//            {
//                while (dr.Read())
//                {
//                    T obj = Activator.CreateInstance<T>();
//                    foreach (var prop in props)
//                    {
//                        var val =
//                          dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
//                        prop.SetValue(obj, val == DBNull.Value ? null : val);
//                    }
//                    objList.Add(obj);
//                }
//            }
//            return objList;
//        }

//        public async Task<List<T>> ExecuteStoredProc<T>(DbCommand command)
//        {
//            using (command)
//            {
//                if (command.Connection.State == System.Data.ConnectionState.Closed)
//                    command.Connection.Open();
//                try
//                {
//                    using (var reader = await command.ExecuteReaderAsync())
//                    {
//                        return MapToList<T>(reader);
//                    }
//                }
//                catch (Exception e)
//                {
//                    throw (e);
//                }
//                finally
//                {
//                    command.Connection.Close();
//                }
//            }
//        }

//        public void ff()
//        {

//        }


//        // public interface await Task<List<T>> ExecuteStoredProc<T>(this DbCommand command)
//    }
//}
