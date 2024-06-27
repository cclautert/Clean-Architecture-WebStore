using AutoMapper;
using WebStore.Core.Entities;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerIdViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
