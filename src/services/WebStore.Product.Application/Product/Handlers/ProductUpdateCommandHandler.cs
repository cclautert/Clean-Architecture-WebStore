using MediatR;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.Product.Commands;

namespace WebStore.Product.Application.Product.Handlers
{
    internal class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   

        public async Task<Domain.Entities.Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetByIdAsync(request.Id);
            Domain.Entities.Product product = null;

            if(productExists is null)
                throw new ApplicationException("Product not found");
            else
            {
                product = new Domain.Entities.Product(product.Name, product.Description, product.Value, product.DateRegister);
                await _productRepository.UpdateAsync(product);
            }

            return product;  
        }
    }
}
