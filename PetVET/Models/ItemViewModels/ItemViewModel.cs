using AutoMapper;
using Newtonsoft.Json;
using PetVET.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.ItemViewModels
{
    public class ItemViewModel : Profile
    {
        [JsonProperty(PropertyName = "itemID")]
        public int ItemID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemName")]
        public string ItemName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemCost")]
        public decimal ItemCost { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemPrice")]
        public decimal ItemPrice { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemExpirationDate")]
        public DateTime ItemExpirationDate { get; set; }

        [JsonProperty(PropertyName = "itemPurchaseDate")]
        public DateTime ItemPurchaseDate { get; set; }

        [JsonProperty(PropertyName = "itemKind")]
        public string ItemKind { get; set; }
    }
}
