using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.OpenHoursViewModels
{
    public class OpenHoursViewModel : Profile
    {
        [JsonProperty(PropertyName = "openHoursID")]
        public int OpenHoursID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "openHoursName")]
        public string OpenHoursName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "openHoursType")]
        public string OpenHoursType { get; set; }


    }
}
