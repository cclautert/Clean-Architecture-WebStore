using WebStore.Product.Application.DTOs;

namespace WebStore.Product.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetProductByIdAsync(Guid id);
        Task CreateAsync(ProductDTO product);
        Task UpdateAsync(ProductDTO product);
        Task RemoveAsync(Guid id);
    }
}
