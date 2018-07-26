using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class CustomerAnimal
    {
        public CustomerAnimal()
        {
            Visit = new HashSet<Visit>();
        }

        public int Rowid { get; set; }
        public int CalCustomerid { get; set; }
        public int CalTyp1 { get; set; }
        public int CalTyp2 { get; set; }
        public string CalName { get; set; }
        public string CalSex { get; set; }
        public string CalColor { get; set; }
        public DateTime? CalBirthdate { get; set; }
        public bool? CalCastrated { get; set; }
        public string CalDescription { get; set; }
        public string CalImg01 { get; set; }
        public string CalChip { get; set; }
        public bool? CalDeath { get; set; }
        public bool? CalNotused { get; set; }
        public string CalCreuser { get; set; }
        public DateTime? CalCredate { get; set; }
        public string CalModuser { get; set; }
        public DateTime? CalModdate { get; set; }

        public Customer CalCustomer { get; set; }
        public Typ1 CalTyp1Navigation { get; set; }
        public Typ2 CalTyp2Navigation { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
