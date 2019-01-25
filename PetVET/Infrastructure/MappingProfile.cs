using AutoMapper;
using PetVET.Database.Models;
using PetVET.Models.CustomerViewModels;
using PetVET.Models.ItemViewModels;
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


            CreateMap<Assortment, ItemViewModel>()
            .ForMember(m => m.ItemCost, opt => opt.MapFrom(vm => vm.AssNtx01))
            .ForMember(m => m.ItemExpirationDate, opt => opt.MapFrom(vm => vm.AssDtx01))
            .ForMember(m => m.ItemID, opt => opt.MapFrom(vm => vm.AssCode))
            .ForMember(m => m.ItemKind, opt => opt.MapFrom(vm => vm.AssTxt01))
            .ForMember(m => m.ItemName, opt => opt.MapFrom(vm => vm.AssDesc))
            .ForMember(m => m.ItemPrice, opt => opt.MapFrom(vm => vm.AssNtx02))
            .ForMember(m => m.ItemPurchaseDate, opt => opt.MapFrom(vm => vm.AssDtx02));


        }
    }
}
