using Newtonsoft.Json;
using PetVetNew.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVetNew.Models.OpenHoursViewModels
{
    public class HolidayDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "holidayName")]
        public string HolidayName { get; set; }


        [JsonProperty(PropertyName = "dateFrom")]
        public DateTime DateFrom { get; set; }


        [JsonProperty(PropertyName = "dateTo")]
        public DateTime DateTo { get; set; }

        [JsonProperty(PropertyName = "month")]
        public Month Month { get; set; }
    }

    public class HolidayStringDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "holidayName")]
        public string HolidayName { get; set; }


        [JsonProperty(PropertyName = "dateFrom")]
        public string DateFrom { get; set; }


        [JsonProperty(PropertyName = "dateTo")]
        public string DateTo { get; set; }

        [JsonProperty(PropertyName = "month")]
        public Month Month { get; set; }

    }
}
