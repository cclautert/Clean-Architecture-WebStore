using AutoMapper;
using WebStore.Product.Application.ViewModels;

namespace WebStore.Products.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<ProductViewModel, Core.Entities.Product>();

            CreateMap<Core.Entities.Product, ProductViewModel>();
            CreateMap<Core.Entities.Product, ProductIdViewModel>();
        }
    }
}
