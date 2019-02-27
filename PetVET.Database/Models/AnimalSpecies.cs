using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class AnimalSpecies
    {
        public AnimalSpecies()
        {
            Animal = new HashSet<Animal>();
        }

        public int Rowid { get; set; }
        public string AnimspiecName { get; set; }
        public string AnimspiecDesc { get; set; }
        public string AnimspiecImg01 { get; set; }
        public bool? AnimspiecNoteused { get; set; }
        public DateTime? AnimspiecCreatedate { get; set; }
        public string AnimspiecCreateby { get; set; }
        public DateTime? AnimspiecUpdatedate { get; set; }
        public string AnimspiecUpdateby { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
