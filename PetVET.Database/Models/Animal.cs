using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Animal
    {
        public Animal()
        {
            CustomerAnimal = new HashSet<CustomerAnimal>();
        }

        public int Rowid { get; set; }
        public int? AnimId { get; set; }
        public string AnimName { get; set; }
        public int? AnimSpeciesid { get; set; }
        public int? AnimRaceid { get; set; }
        public DateTime? AnimBirthdate { get; set; }
        public string AnimChip { get; set; }
        public string AnimSex { get; set; }
        public string AnimCoat { get; set; }
        public bool? AnimCastrated { get; set; }
        public DateTime? AnimCreatedate { get; set; }
        public string AnimCreateby { get; set; }
        public DateTime? AnimUpdatedate { get; set; }
        public string AnimUpdateby { get; set; }

        public AnimalRace AnimRace { get; set; }
        public AnimalSpecies AnimSpecies { get; set; }
        public ICollection<CustomerAnimal> CustomerAnimal { get; set; }
    }
}
