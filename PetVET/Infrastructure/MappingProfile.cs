using AutoMapper;
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
                .ForMember(m => m.Rowid, opt => opt.MapFrom(vm => vm.Rowid))
                .ForMember(m => m.CustFirstname, opt => opt.MapFrom(vm => vm.CustFirstname))
                .ForMember(m => m.CustLastname, opt => opt.MapFrom(vm => vm.CustLastname))
                .ForMember(m => m.CustMail, opt => opt.MapFrom(vm => vm.CustMail))
                .ForMember(m => m.CustPhone, opt => opt.MapFrom(vm => vm.CustPhone))
                .ForMember(m => m.CustBirthdate, opt => opt.MapFrom(vm => vm.CustBirthdate))
                .ForMember(m => m.CustStreet, opt => opt.MapFrom(vm => vm.CustStreet))
                .ForMember(m => m.CustHouse, opt => opt.MapFrom(vm => vm.CustHouse))
                .ForMember(m => m.CustFlat, opt => opt.MapFrom(vm => vm.CustFlat))
                .ForMember(m => m.CustCity, opt => opt.MapFrom(vm => vm.CustCity))
                .ForMember(m => m.CustCitycode, opt => opt.MapFrom(vm => vm.CustCitycode))
                .ForMember(m => m.CustNotused, opt => opt.MapFrom(vm => vm.CustNotused))
                .ForMember(m => m.CustAgree1, opt => opt.MapFrom(vm => vm.CustAgree1))
                .ForMember(m => m.CustAgree2, opt => opt.MapFrom(vm => vm.CustAgree2))
                .ForMember(m => m.CustAgree3, opt => opt.MapFrom(vm => vm.CustAgree3));

            CreateMap<Customer, CustomerViewModel>()
             .ForMember(m => m.Rowid, opt => opt.MapFrom(vm => vm.Rowid))
                .ForMember(m => m.CustFirstname, opt => opt.MapFrom(vm => vm.CustFirstname))
                .ForMember(m => m.CustLastname, opt => opt.MapFrom(vm => vm.CustLastname))
                .ForMember(m => m.CustMail, opt => opt.MapFrom(vm => vm.CustMail))
                .ForMember(m => m.CustPhone, opt => opt.MapFrom(vm => vm.CustPhone))
                .ForMember(m => m.CustBirthdate, opt => opt.MapFrom(vm => vm.CustBirthdate))
                .ForMember(m => m.CustStreet, opt => opt.MapFrom(vm => vm.CustStreet))
                .ForMember(m => m.CustHouse, opt => opt.MapFrom(vm => vm.CustHouse))
                .ForMember(m => m.CustFlat, opt => opt.MapFrom(vm => vm.CustFlat))
                .ForMember(m => m.CustCity, opt => opt.MapFrom(vm => vm.CustCity))
                .ForMember(m => m.CustCitycode, opt => opt.MapFrom(vm => vm.CustCitycode))
                .ForMember(m => m.CustNotused, opt => opt.MapFrom(vm => vm.CustNotused))
                .ForMember(m => m.CustAgree1, opt => opt.MapFrom(vm => vm.CustAgree1))
                .ForMember(m => m.CustAgree2, opt => opt.MapFrom(vm => vm.CustAgree2))
                .ForMember(m => m.CustAgree3, opt => opt.MapFrom(vm => vm.CustAgree3));


            CreateMap<ServiceViewModel, Servic>()
           .ForMember(m => m.Rowid, opt => opt.MapFrom(vm => vm.Rowid))
           .ForMember(m => m.ServicName, opt => opt.MapFrom(vm => vm.ServicName))
           .ForMember(m => m.ServicTypeid, opt => opt.MapFrom(vm => vm.ServicTypeid))
           .ForMember(m => m.ServicCost, opt => opt.MapFrom(vm => vm.ServicCost))
           .ForMember(m => m.ServicTaxid, opt => opt.MapFrom(vm => vm.ServicTaxid))
           .ForMember(m => m.ServicDuration, opt => opt.MapFrom(vm => vm.ServicDuration))
           .ForMember(m => m.ServicOfficeid, opt => opt.MapFrom(vm => vm.ServicOfficeid));


            CreateMap<Servic, ServiceViewModel>()
          .ForMember(m => m.Rowid, opt => opt.MapFrom(vm => vm.Rowid))
          .ForMember(m => m.ServicName, opt => opt.MapFrom(vm => vm.ServicName))
          .ForMember(m => m.ServicTypeid, opt => opt.MapFrom(vm => vm.ServicTypeid))
          .ForMember(m => m.ServicCost, opt => opt.MapFrom(vm => vm.ServicCost))
          .ForMember(m => m.ServicTaxid, opt => opt.MapFrom(vm => vm.ServicTaxid))
          .ForMember(m => m.ServicDuration, opt => opt.MapFrom(vm => vm.ServicDuration))
          .ForMember(m => m.ServicOfficeid, opt => opt.MapFrom(vm => vm.ServicOfficeid));

           

           
        }
    }
}
