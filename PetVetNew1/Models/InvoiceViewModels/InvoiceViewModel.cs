using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.InvoiceViewModels
{
    public class InvoiceViewModel : Profile
    {
        [JsonProperty(PropertyName = "invoiceID")]
        public int InvoiceID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "invoiceTyp")]
        public string InvoiceTyp { get; set; }



    }
}
