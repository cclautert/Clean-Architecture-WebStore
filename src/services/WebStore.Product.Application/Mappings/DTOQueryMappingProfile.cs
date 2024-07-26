using AutoMapper;
using WebStore.Product.Application.DTOs;

namespace WebStore.Product.Application.Mappings
{
    public class DTOQueryMappingProfile : Profile
    {
        public DTOQueryMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDTO>().ReverseMap();
            CreateMap<IEnumerable<Domain.Entities.Product>, IEnumerable<ProductDTO>>().ReverseMap();
        }
    }
}
