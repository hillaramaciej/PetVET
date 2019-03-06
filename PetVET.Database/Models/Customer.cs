using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAnimal = new HashSet<CustomerAnimal>();
            OfficeCustomer = new HashSet<OfficeCustomer>();
        }

        public int Rowid { get; set; }
        public string CustFirstname { get; set; }
        public string CustLastname { get; set; }
        public string CustMail { get; set; }
        public string CustPhone { get; set; }
        public DateTime? CustBirthdate { get; set; }
        public string CustStreet { get; set; }
        public string CustHouse { get; set; }
        public string CustFlat { get; set; }
        public string CustCity { get; set; }
        public string CustCitycode { get; set; }
        public byte? CustAgree1 { get; set; }
        public byte? CustAgree2 { get; set; }
        public byte? CustAgree3 { get; set; }
        public byte? CustAgree4 { get; set; }
        public byte? CustAgree5 { get; set; }
        public bool? CustNotused { get; set; }
        public DateTime? CustCreatedate { get; set; }
        public string CustCreateby { get; set; }
        public DateTime? CustUpdatedate { get; set; }
        public string CustUpdateby { get; set; }

        public virtual ICollection<CustomerAnimal> CustomerAnimal { get; set; }
        public virtual ICollection<OfficeCustomer> OfficeCustomer { get; set; }
    }
}
