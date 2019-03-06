using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using PetVET.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.PetViewModels
{
    public class PetViewModel : Profile , IViewModel
    {
        [JsonProperty(PropertyName = "petId")]
        public int PetID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "species")]
        public string Species { get; set; }

        [Required]
        [JsonProperty(PropertyName = "race")]
        public string Race { get; set; }

        [Required]
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty(PropertyName = "chipNumber")]
        public int ChipNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; set; }

        [Required]
        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        [JsonProperty(PropertyName = "coat")]
        public string Coat { get; set; }

        [JsonProperty(PropertyName = "castrated")]
        bool Castrated { get; set; }

    }
}
