using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Typ1
    {
        public Typ1()
        {
            CustomerAnimal = new HashSet<CustomerAnimal>();
            Typ2 = new HashSet<Typ2>();
        }

        public int Rowid { get; set; }
        public string Typ1Desc { get; set; }
        public bool? Typ1Notused { get; set; }
        public string Typ1Creuser { get; set; }
        public DateTime? Typ1Credate { get; set; }
        public string Typ1Moduser { get; set; }
        public DateTime? Typ1Moddate { get; set; }

        public ICollection<CustomerAnimal> CustomerAnimal { get; set; }
        public ICollection<Typ2> Typ2 { get; set; }
    }
}
