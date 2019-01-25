using AutoMapper;
using Newtonsoft.Json;
using PetVET.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.CustomerViewModels
{
    public class CustomerViewModel :  IViewModel
    {      

        [JsonProperty(PropertyName ="userId")]
        public int UserID { get; set; }

        [Required]
        [JsonProperty(PropertyName= "firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        [Required]
        [JsonProperty(PropertyName = "phonNumber")]
        public string PhonNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [Required]
        [JsonProperty(PropertyName = "houseNumber")]
        public int HouseNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "flatNumber")]
        public int FlatNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Required]
        [JsonProperty(PropertyName = "cityCode")]
        public int CityCode { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "isNewCustomer")]
        bool IsNew { get; set; }
    }
}
