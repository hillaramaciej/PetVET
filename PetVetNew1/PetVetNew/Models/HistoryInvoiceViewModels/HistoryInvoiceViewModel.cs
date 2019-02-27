using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.HistoryInvoiceViewModels
{
    public class HistoryInvoiceViewModel : Profile
    {
        [JsonProperty(PropertyName = "historyInvoiceID")]
        public int HistoryInvoiceID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "historyInvoiceName")]
        public string HistoryInvoiceName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "historyInvoiceType")]
        public string HistoryInvoiceType { get; set; }


    }
}
