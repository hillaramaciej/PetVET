using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.CustomerViewModels
{
    public class CustomerQuickSearchcsDTO
    {          
        public string Search { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public int Step { get; set; }
    }
}
