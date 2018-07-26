using System;
using System.Collections.Generic;

namespace PetVET.Database.Models
{
    public partial class Visit
    {
        public Visit()
        {
            Invoice = new HashSet<Invoice>();
            VisitMedicines = new HashSet<VisitMedicines>();
            VisitTreatment = new HashSet<VisitTreatment>();
        }

        public int Rowid { get; set; }
        public int VisCustomerid { get; set; }
        public int? VisAnimalid { get; set; }
        public int VisDepartmentid { get; set; }
        public int VisVet { get; set; }
        public DateTime? VisDate { get; set; }
        public string VisMedicalhistory { get; set; }
        public string VisRecognition { get; set; }
        public decimal? VisWeight { get; set; }
        public string VisDiet { get; set; }
        public string VisRecommendations { get; set; }
        public decimal? VisCost { get; set; }
        public string VisTxt01 { get; set; }
        public string VisTxt02 { get; set; }
        public string VisTxt03 { get; set; }
        public string VisTxt04 { get; set; }
        public string VisTxt05 { get; set; }
        public DateTime? VisDtx01 { get; set; }
        public DateTime? VisDtx02 { get; set; }
        public DateTime? VisDtx03 { get; set; }
        public DateTime? VisDtx04 { get; set; }
        public DateTime? VisDtx05 { get; set; }
        public decimal? VisNtx01 { get; set; }
        public decimal? VisNtx02 { get; set; }
        public decimal? VisNtx03 { get; set; }
        public decimal? VisNtx04 { get; set; }
        public decimal? VisNtx05 { get; set; }
        public bool? VisNotused { get; set; }
        public string VisCreuser { get; set; }
        public DateTime? VisCredate { get; set; }
        public string VisModuser { get; set; }
        public DateTime? VisModdate { get; set; }

        public CustomerAnimal VisAnimal { get; set; }
        public Customer VisCustomer { get; set; }
        public OfficeDepartment VisDepartment { get; set; }
        public Vet VisVetNavigation { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<VisitMedicines> VisitMedicines { get; set; }
        public ICollection<VisitTreatment> VisitTreatment { get; set; }
    }
}
