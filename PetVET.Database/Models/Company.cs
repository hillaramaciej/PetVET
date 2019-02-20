using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Company
    {
        public Company()
        {
            Office = new HashSet<Office>();
        }

        public int Rowid { get; set; }
        public string CompName { get; set; }
        public string CompOfficename { get; set; }
        public string CompPhone { get; set; }
        public string CompDesc { get; set; }
        public string CompFb { get; set; }
        public string CompInsta { get; set; }
        public string CompWww { get; set; }
        public byte? CompTrade01 { get; set; }
        public byte? CompTrade02 { get; set; }
        public byte? CompTrade03 { get; set; }
        public byte? CompTrade04 { get; set; }
        public byte? CompTrade05 { get; set; }
        public byte? CompTrade06 { get; set; }
        public byte? CompTrade07 { get; set; }
        public byte? CompTrade08 { get; set; }
        public byte? CompTrade09 { get; set; }
        public byte? CompTrade10 { get; set; }
        public byte? CompTradedef { get; set; }
        public string CompImg01 { get; set; }
        public DateTime? CompCreatedate { get; set; }
        public string CompCreateby { get; set; }
        public DateTime? CompUpdatedate { get; set; }
        public string CompUpdateby { get; set; }

        public ICollection<Office> Office { get; set; }
    }
}
