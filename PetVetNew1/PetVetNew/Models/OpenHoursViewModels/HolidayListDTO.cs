using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVetNew.Models.OpenHoursViewModels
{
    public class HolidayListDTO
    {
        [JsonProperty(PropertyName ="holidayList")]
        public List<HolidayDTO> List { get; set; }
    }
}
