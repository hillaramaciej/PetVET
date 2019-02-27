using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Models.SuperAdmin
{
    public class AddOrganizationViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        
        [JsonProperty(PropertyName = "organizationId")]
        public int organizationId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "licenseCount")]
        public int LicenseCount { get; set; }        

    }
}
