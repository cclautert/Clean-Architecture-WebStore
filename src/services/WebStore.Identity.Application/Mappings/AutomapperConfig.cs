using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.Application.Mappings
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerIdViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
