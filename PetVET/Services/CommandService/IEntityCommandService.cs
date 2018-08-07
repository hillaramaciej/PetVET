using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository.Core
{
    public interface  IEntityCommandService<EntityIn, EntityOut, Error> where EntityIn : IViewModel where EntityOut :IViewModel where Error : IErrorViewModel
    {
        Task<ProcedureResult<EntityOut, Error>> ExecuteStoredProc(string storedProcName, EntityIn viewModel);       
    }
}
