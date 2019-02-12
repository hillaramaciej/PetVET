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
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "pWZNumber")]
        public int PWZNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "permit")]
        public string Permit { get; set; }

        [Required]
        [JsonProperty(PropertyName = "UserAdded")]
        public string UserAdded { get; set; }
    }
}
