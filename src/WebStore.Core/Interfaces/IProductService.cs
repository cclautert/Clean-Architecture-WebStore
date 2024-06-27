using WebStore.Core.Entities;

namespace WebStore.Core.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(Guid id);
    }
}
