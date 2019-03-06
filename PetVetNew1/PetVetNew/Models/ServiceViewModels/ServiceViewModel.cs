using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.ServiceViewModels
{
    public class ServiceViewModel : Profile
    {
        [JsonProperty(PropertyName = "rowid")]
        public int Rowid { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicName")]
        public string ServicName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicTypeid")]
        public string ServicTypeid { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicCost")]
        public int ServicCost { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicTaxid")]
        public int ServicTaxid { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicDuration")]
        public int ServicDuration { get; set; }

        [Required]
        [JsonProperty(PropertyName = "servicOfficeid")]
        public int ServicOfficeid { get; set; }
    }
}
