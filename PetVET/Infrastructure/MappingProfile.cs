using AutoMapper;
using PetVET.Database.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Models.ItemViewModels;
using PetVET.Models.PetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(m => m.CusName, opt => opt.MapFrom(vm => vm.FirstName))
                .ForMember(m => m.CusLastname, opt => opt.MapFrom(vm => vm.LastName))
                .ForMember(m => m.CusEmail, opt => opt.MapFrom(vm => vm.Mail))
                .ForMember(m => m.CusPhone, opt => opt.MapFrom(vm => vm.PhonNumber));

            CreateMap<Customer, CustomerViewModel>()
             .ForMember(m => m.FirstName, opt => opt.MapFrom(vm => vm.CusName))
             .ForMember(m => m.LastName , opt => opt.MapFrom(vm => vm.CusLastname))
             .ForMember(m => m.Mail , opt => opt.MapFrom(vm => vm.CusEmail))
             .ForMember(m => m.City , opt => opt.MapFrom(vm => vm.CusCity))
             .ForMember(m => m.UserID , opt => opt.MapFrom(vm => vm.Rowid))
             .ForMember(m => m.PhonNumber, opt => opt.MapFrom(vm => vm. CusPhone));


            CreateMap<ItemViewModel, Assortment>()
            .ForMember(m => m.AssNtx01, opt => opt.MapFrom(vm => vm.ItemCost))
            .ForMember(m => m.AssDtx01, opt => opt.MapFrom(vm => vm.ItemExpirationDate))
            .ForMember(m => m.AssCode, opt => opt.MapFrom(vm => vm.ItemID))
            .ForMember(m => m.AssTxt01, opt => opt.MapFrom(vm => vm.ItemKind))
            .ForMember(m => m.AssDesc, opt => opt.MapFrom(vm => vm.ItemName))
            .ForMember(m => m.AssNtx02, opt => opt.MapFrom(vm => vm.ItemPrice))
            .ForMember(m => m.AssDtx02, opt => opt.MapFrom(vm => vm.ItemPurchaseDate));

            CreateMap<PetViewModel, CustomerAnimal>()
            .ForMember(m => m.CalName, opt => opt.MapFrom(vm => vm.Name))
            .ForMember(m => m.CalTyp1, opt => opt.MapFrom(vm => vm.Species))
            .ForMember(m => m.CalTyp2, opt => opt.MapFrom(vm => vm.Race))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Age))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.ChipNumber))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Weight))
            .ForMember(m => m.CalSex, opt => opt.MapFrom(vm => vm.Sex));
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Coat));
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Castrated)); 


        }
    }
}
