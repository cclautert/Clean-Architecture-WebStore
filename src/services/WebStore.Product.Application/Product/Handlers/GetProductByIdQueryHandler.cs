using MediatR;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.Product.Commands;

namespace WebStore.Product.Application.Product.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<ProductCreateCommand, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   
        
        public async Task<Domain.Entities.Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
