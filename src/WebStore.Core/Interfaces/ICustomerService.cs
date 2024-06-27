using WebStore.Core.Entities;

namespace WebStore.Core.Interfaces
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(Guid id);
    }
}
