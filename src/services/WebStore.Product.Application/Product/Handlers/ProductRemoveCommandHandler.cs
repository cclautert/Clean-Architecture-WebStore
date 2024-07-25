using MediatR;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.Product.Commands;

namespace WebStore.Product.Application.Product.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   

        public async Task<Domain.Entities.Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetByIdAsync(request.Id);
            Domain.Entities.Product product = null;

            if(productExists is null)
                throw new ApplicationException("Product not found");
            else
            {
                await _productRepository.RemoveAsync(request.Id);

                return productExists;
            }
        }
    }
}
