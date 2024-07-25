using AutoMapper;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Product.Commands;

namespace WebStore.Product.Application.Mappings
{
    public class DTOCommandMappingProfile : Profile
    {
        public DTOCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
