using AutoMapper;
using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Customer 
    {
        public Customer()
        {
            CustomerAnimal = new HashSet<CustomerAnimal>();
            Visit = new HashSet<Visit>();
           
        }

        public int Rowid { get; set; }
        public string CusName { get; set; }
        public string CusLastname { get; set; }
        public string CusAddress { get; set; }
        public string CusCity { get; set; }
        public string CusZipcode { get; set; }
        public string CusPhone { get; set; }
        public string CusPhone2 { get; set; }
        public string CusEmail { get; set; }
        public string CusEmail2 { get; set; }
        public bool? CusApproval { get; set; }
        public string CusApprovalnum { get; set; }
        public string CusTxt01 { get; set; }
        public string CusTxt02 { get; set; }
        public string CusTxt03 { get; set; }
        public string CusTxt04 { get; set; }
        public string CusTxt05 { get; set; }
        public DateTime? CusDtx01 { get; set; }
        public DateTime? CusDtx02 { get; set; }
        public DateTime? CusDtx03 { get; set; }
        public DateTime? CusDtx04 { get; set; }
        public DateTime? CusDtx05 { get; set; }
        public decimal? CusNtx01 { get; set; }
        public decimal? CusNtx02 { get; set; }
        public decimal? CusNtx03 { get; set; }
        public decimal? CusNtx04 { get; set; }
        public decimal? CusNtx05 { get; set; }
        public bool? CusNotused { get; set; }
        public string CusCreuser { get; set; }
        public DateTime? CusCredate { get; set; }
        public string CusModuser { get; set; }
        public DateTime? CusModdate { get; set; }

        public ICollection<CustomerAnimal> CustomerAnimal { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
