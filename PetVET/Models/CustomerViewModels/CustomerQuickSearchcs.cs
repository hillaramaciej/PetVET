using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.CustomerViewModels
{
    public class CustomerQuickSearchcsDTO
    {          
        public string Search { get; set; }
        public int Page { get; set; }
        public int Step { get; set; }
    }
}
