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

        [JsonProperty(PropertyName = "rowid")]
        public int Rowid { get; set; }

        [Required]
        [JsonProperty(PropertyName= "custFirstname")]
        public string CustFirstname { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custLastname")]
        public string CustLastname { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [JsonProperty(PropertyName = "custMail")]
        public string CustMail { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custPhone")]
        public string CustPhone { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custBirthdate")]
        public string CustBirthdate { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custStreet")]
        public string CustStreet { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custHouse")]
        public string CustHouse { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custFlat")]
        public string CustFlat { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custCity")]
        public string CustCity { get; set; }

        [Required]
        [JsonProperty(PropertyName = "custCitycode")]
        public int CustCitycode { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "custNotused")]
        public bool ? CustNotused { get; set; }

        [JsonProperty(PropertyName = "custAgree1")]
        public  bool ? CustAgree1 { get; set; }

        [JsonProperty(PropertyName = "CustAgree2")]
        public bool ? CustAgree2 { get; set; }

        [JsonProperty(PropertyName = "CustAgree3")]
        public bool ? CustAgree3 { get; set; }
    }
}
