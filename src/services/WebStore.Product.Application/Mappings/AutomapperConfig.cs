using AutoMapper;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.ViewModels;

namespace WebStore.Product.Application.Mappings
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<ProductViewModel, Domain.Entities.Product>().ReverseMap();
            CreateMap<Domain.Entities.Product, ProductIdViewModel>().ReverseMap();

            CreateMap<Domain.Entities.Product, ProductDTO>().ReverseMap();
        }
    }
}
