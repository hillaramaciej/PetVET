using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.EquipmentViewModels
{
    public class EquipmentViewModel : Profile
    {
        [JsonProperty(PropertyName = "equipmentID")]
        public int EquipmentID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "equipmentName")]
        public string EquipmentName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "equipmentType")]
        public string EquipmentType { get; set; }


    }
}
