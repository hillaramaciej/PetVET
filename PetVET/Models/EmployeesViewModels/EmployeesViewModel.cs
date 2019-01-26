using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using PetVET.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.EmployeesViewModels
{
    public class EmployeesViewModel : Profile , IViewModel
    {
        [JsonProperty(PropertyName = "petId")]
        public int EmployeeID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceName")]
        public string EmployeeName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceCost")]
        public double EmployeeMail { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceCost")]
        public double EmployeeTel { get; set; }

        [Required]
        [JsonProperty(PropertyName = "serviceType")]
        public string EmployeeType { get; set; }




    }
}
