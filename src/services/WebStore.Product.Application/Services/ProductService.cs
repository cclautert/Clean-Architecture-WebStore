using WebStore.Core.Entities.Validations;
using WebStore.Core.Interfaces;

namespace WebStore.Product.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository produtoRepository,
                              INotifier notificador) : base(notificador)
        {
            _productRepository = produtoRepository;
        }

        public async Task CreateAsync(Core.Entities.Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;

            var ExistingProduct = await _productRepository.GetByIdAsync(product.Id);

            if(ExistingProduct.Name != null)
            {
                Notify("Já existe um produto com o ID informado!");
                return;
            }

            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(Core.Entities.Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;

            await _productRepository.UpdateAsync(product);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _productRepository.RemoveAsync(id);
        }
    }
}
