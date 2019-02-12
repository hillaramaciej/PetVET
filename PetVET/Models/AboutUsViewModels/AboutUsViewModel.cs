using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.AboutUsViewModels
{
    public class AboutUsViewModel : Profile
    {
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "cabinetName")]
        public string CabinetName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [Required]
        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }

        [Required]
        [JsonProperty(PropertyName = "fB")]
        public string FB { get; set; }

        [Required]
        [JsonProperty(PropertyName = "insta")]
        public string Insta { get; set; }

        [Required]
        [JsonProperty(PropertyName = "wWW")]
        public string WWW { get; set; }

    }
}
