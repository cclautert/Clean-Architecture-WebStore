using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Interfaces;
using WebStore.Product.Application.ViewModels;

namespace WebStore.Products.API.Controllers
{
    [Route("api/products")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
                                 IMapper mapper,
                                 INotifier notificator) : base(notificator)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productService.GetAllAsync());                               
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            var productViewModel = await GetProductById(id);

            if (productViewModel == null) return NotFound();

            return productViewModel;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductViewModel>> Create(ProductDTO produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.CreateAsync(_mapper.Map<ProductDTO>(produtoViewModel));

            return CustomResponse(HttpStatusCode.Created ,produtoViewModel);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, ProductDTO produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var productUpdated = await GetProductById(id);
            
            productUpdated.Name = produtoViewModel.Name;
            productUpdated.Description = produtoViewModel.Description;
            productUpdated.Value = produtoViewModel.Value;
            //productUpdated.DateRegister = produtoViewModel.DateRegister;

            await _productService.UpdateAsync(_mapper.Map<ProductDTO>(productUpdated));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {
            var product = await GetProductById(id);

            if (product == null) return NotFound();

            await _productService.RemoveAsync(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProductDTO> GetProductById(Guid id)
        {
            return _mapper.Map<ProductDTO>(await _productService.GetProductByIdAsync(id));
        }
    }
}