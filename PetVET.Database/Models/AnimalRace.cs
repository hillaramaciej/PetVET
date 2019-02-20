using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class AnimalRace
    {
        public AnimalRace()
        {
            Animal = new HashSet<Animal>();
        }

        public int Rowid { get; set; }
        public int? AnimracSpieciesid { get; set; }
        public string AnimracName { get; set; }
        public string AnimracDesc { get; set; }
        public string AnimracImg01 { get; set; }
        public bool? AnimracNoteused { get; set; }
        public DateTime? AnimracCreatedate { get; set; }
        public string AnimracCreateby { get; set; }
        public DateTime? AnimracUpdatedate { get; set; }
        public string AnimracUpdateby { get; set; }

        public ICollection<Animal> Animal { get; set; }
    }
}
