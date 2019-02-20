﻿using AutoMapper;
using PetVET.Database.Models;
using PetVET.Models._Common;
using PetVET.Models.CustomerViewModels;
using PetVET.Models.EmployeesViewModels;
using PetVET.Models.ItemViewModels;
using PetVET.Models.PetViewModels;
using PetVET.Models.ServiceViewModels;
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
            

            CreateMap<Servic, DllDTO>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Rowid))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.ServicDesc));

            CreateMap<CustomerViewModel, Customer>()
                .ForMember(m => m.CustFirstname, opt => opt.MapFrom(vm => vm.FirstName))
                .ForMember(m => m.CustLastname, opt => opt.MapFrom(vm => vm.LastName))
                .ForMember(m => m.CustMail, opt => opt.MapFrom(vm => vm.Mail))
                .ForMember(m => m.CustPhone, opt => opt.MapFrom(vm => vm.PhonNumber));

            CreateMap<Customer, CustomerViewModel>()
             .ForMember(m => m.FirstName, opt => opt.MapFrom(vm => vm.CustFirstname))
             .ForMember(m => m.LastName, opt => opt.MapFrom(vm => vm.CustLastname))
             .ForMember(m => m.Mail, opt => opt.MapFrom(vm => vm.CustMail))
             .ForMember(m => m.City, opt => opt.MapFrom(vm => vm.CustCity))
             .ForMember(m => m.UserID, opt => opt.MapFrom(vm => vm.Rowid))
             .ForMember(m => m.PhonNumber, opt => opt.MapFrom(vm => vm.CustPhone));

            CreateMap<ItemViewModel, Assortment>()
            .ForMember(m => m.AssortPrice, opt => opt.MapFrom(vm => vm.ItemCost));
            //.ForMember(m => m.ex, opt => opt.MapFrom(vm => vm.ItemExpirationDate))
            //.ForMember(m => m.AssCode, opt => opt.MapFrom(vm => vm.ItemID))
            //.ForMember(m => m.AssTxt01, opt => opt.MapFrom(vm => vm.ItemKind))
            //.ForMember(m => m.AssDesc, opt => opt.MapFrom(vm => vm.ItemName))
            //.ForMember(m => m.AssNtx02, opt => opt.MapFrom(vm => vm.ItemPrice))
            //.ForMember(m => m.AssDtx02, opt => opt.MapFrom(vm => vm.ItemPurchaseDate));

            CreateMap<PetViewModel, CustomerAnimal>();
            //.ForMember(m => m.CalName, opt => opt.MapFrom(vm => vm.Name))
            //.ForMember(m => m.CalTyp1, opt => opt.MapFrom(vm => vm.Species))
            //.ForMember(m => m.CalTyp2, opt => opt.MapFrom(vm => vm.Race))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Age))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.ChipNumber))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Weight))
            //.ForMember(m => m.CalSex, opt => opt.MapFrom(vm => vm.Sex));
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Coat));
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Castrated)); 

            CreateMap<ServiceViewModel, Servic>()
            .ForMember(m => m.ServicDesc, opt => opt.MapFrom(vm => vm.ServiceName))
            //.ForMember(m => m.TreOdt, opt => opt.MapFrom(vm => vm.OfficeId))
            //.ForMember(m => m.TrePkwiu, opt => opt.MapFrom(vm => vm.ServiceType))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Species))
            //.ForMember(m => m.CalTyp2, opt => opt.MapFrom(vm => vm.Race))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Age))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.ChipNumber))
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Weight))
            .ForMember(m => m.ServicCost, opt => opt.MapFrom(vm => vm.ServiceCost));
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Coat));
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Castrated)); 



            CreateMap<EmployeesViewModel, Employee>();
            //.ForMember(m => m., opt => opt.MapFrom(vm => vm.Address))
            ////.ForMember(m => m.TreOdt, opt => opt.MapFrom(vm => vm.OfficeId))
            ////.ForMember(m => m.TrePkwiu, opt => opt.MapFrom(vm => vm.ServiceType))
            //////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Species))
            ////.ForMember(m => m.CalTyp2, opt => opt.MapFrom(vm => vm.Race))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Age))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.ChipNumber))
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Weight))
            //.ForMember(m => m.TreCost, opt => opt.MapFrom(vm => vm.ServiceCost));
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Coat));
            ////.ForMember(m => m., opt => opt.MapFrom(vm => vm.Castrated)); 
        }
    }
}
