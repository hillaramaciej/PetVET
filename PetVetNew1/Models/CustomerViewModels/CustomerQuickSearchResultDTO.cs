using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.CustomerViewModels
{
    public class CustomerQuickSearchResultDTO
    {
        public IEnumerable<CustomerViewModel> Result { get; set; }
        public int Count { get; set; }
        public int PagesNumber { get; set; }
    }
}
