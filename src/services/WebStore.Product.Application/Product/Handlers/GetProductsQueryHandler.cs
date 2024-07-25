using MediatR;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.Product.Queries;

namespace WebStore.Product.Application.Product.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
