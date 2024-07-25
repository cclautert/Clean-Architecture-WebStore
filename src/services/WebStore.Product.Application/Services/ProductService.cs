using AutoMapper;
using WebStore.Domain.Entities.Validations;
using WebStore.Domain.Interfaces;
using WebStore.Domain.Services;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Interfaces;
using WebStore.Domain.Entities;

namespace WebStore.Product.Application.Services
{ public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository produtoRepository,
            INotifier notificador, IMapper mapper) : base(notificador)
        {
            _productRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetAllAsync());                               
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Domain.Entities.Product>(productDto);

            if (!RunValidation(new ProductValidation(), product)) return;

            var ExistingProduct = await _productRepository.GetByIdAsync(product.Id);

            if(ExistingProduct.Name != null)
            {
                Notify("Já existe um produto com o ID informado!");
                return;
            }

            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Domain.Entities.Product>(productDto);

            if (!RunValidation(new ProductValidation(), product)) return;

            await _productRepository.UpdateAsync(product);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _productRepository.RemoveAsync(id);
        }
    }
}
