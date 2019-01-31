using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.CategoryViewModels
{
    public class CategoryViewModel : Profile
    {
        [JsonProperty(PropertyName = "categoryID")]
        public int CategoryID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }



    }
}
