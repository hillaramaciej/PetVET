using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Typ2
    {
        public Typ2()
        {
            CustomerAnimal = new HashSet<CustomerAnimal>();
        }

        public int Rowid { get; set; }
        public int Typ2Typ1id { get; set; }
        public string Typ2Desc { get; set; }
        public bool? Typ2Notused { get; set; }
        public string Typ2Creuser { get; set; }
        public DateTime? Typ2Credate { get; set; }
        public string Typ2Moduser { get; set; }
        public DateTime? Typ2Moddate { get; set; }

        public Typ1 Typ2Typ1 { get; set; }
        public ICollection<CustomerAnimal> CustomerAnimal { get; set; }
    }
}
