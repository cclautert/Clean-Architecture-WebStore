using AutoMapper;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Product.Queries;

namespace WebStore.Product.Application.Mappings
{
    public class DTOQueryMappingProfile : Profile
    {
        public DTOQueryMappingProfile()
        {
            CreateMap<GetProductsQuery, IEnumerable<ProductDTO>>().ReverseMap();
        }
    }
}
