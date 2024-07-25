using MediatR;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.Product.Commands;

namespace WebStore.Product.Application.Product.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   

        public async Task<Domain.Entities.Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.Name, request.Description, request.Value, request.DateRegister);

            await _productRepository.CreateAsync(product);

            return product; 
        }
    }
}
