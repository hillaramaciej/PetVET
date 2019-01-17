using System.Collections.Generic;

namespace PetVET.Repository.Core
{
    public class ProcedureResult<EntityOut, Error> where EntityOut : IViewModel where Error : IErrorViewModel
    {
        public List<EntityOut>  Result { get; set; }
        public Error _Error { get; set; }
    }
}