using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class CustomerAnimal
    {
        public CustomerAnimal()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Rowid { get; set; }
        public int? CustanimAnimalid { get; set; }
        public int? CustanimCustomerid { get; set; }
        public DateTime? CustanimCreatedate { get; set; }
        public string CustanimCreateby { get; set; }
        public DateTime? CustanimUpdatedate { get; set; }
        public string CustanimUpdateby { get; set; }

        public virtual Animal CustanimAnimal { get; set; }
        public virtual Customer CustanimCustomer { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
