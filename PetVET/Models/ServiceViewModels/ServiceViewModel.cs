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
        [JsonProperty(PropertyName = "serviceId")]
        public int ServiceID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceName")]
        public string ServiceName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceCost")]
        public int ServiceCost { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceDuration")]
        public int ServiceDuration { get; set; }

    }
}
