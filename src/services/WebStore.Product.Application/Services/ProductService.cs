using AutoMapper;
using MediatR;
using WebStore.Domain.Entities.Validations;
using WebStore.Domain.Interfaces;
using WebStore.Domain.Services;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Interfaces;
using WebStore.Domain.Entities;
using WebStore.Product.Application.Product.Commands;
using WebStore.Product.Application.Product.Queries;

namespace WebStore.Product.Application.Services
{ public class ProductService : BaseService, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(INotifier notificador, IMapper mapper, IMediator mediator) : base(notificador)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception(nameof(productsQuery) + "Could not be loaded");
            var lstProducts = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(lstProducts);
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            var productByIdQuery = new GetProductByIdQuery(id);

            if (productByIdQuery == null)
                throw new Exception(nameof(productByIdQuery) + "Could not be loaded");

            return _mapper.Map<ProductDTO>(await _mediator.Send(productByIdQuery));
        }

        public async Task CreateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Domain.Entities.Product>(productDto);

            if (!RunValidation(new ProductValidation(), product)) return;

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            var ExistingProduct = await GetProductByIdAsync(product.Id);

            if(ExistingProduct.Name != null)
            {
                Notify("Já existe um produto com o ID informado!");
                return;
            }

            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            //if (!RunValidation(new ProductValidation(), product)) return;

            await _mediator.Send(productUpdateCommand);
        }

        public async Task RemoveAsync(Guid id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id);

            if (productRemoveCommand == null)
                throw new Exception(nameof(productRemoveCommand) + "Could not be loaded");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
