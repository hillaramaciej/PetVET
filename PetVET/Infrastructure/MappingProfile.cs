using AutoMapper;
using PetVET.Database.Models;
using PetVET.Models.CustomerViewModels;
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
        }
    }
}
