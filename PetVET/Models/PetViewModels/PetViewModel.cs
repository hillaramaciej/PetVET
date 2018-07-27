using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.PetViewModels
{
    public class PetViewModel : Profile
    {
        [JsonProperty(PropertyName = "petId")]
        public int PetID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "petType1")]
        public int PetType1 { get; set; }

        [Required]
        [JsonProperty(PropertyName = "petType2")]
        public int PetType2 { get; set; }

        [Required]
        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        [JsonProperty(PropertyName = "chipNo")]
        public string ChipNo { get; set; }
    }
}
