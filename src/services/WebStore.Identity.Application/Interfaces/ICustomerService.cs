using WebStore.Identity.Application.DTOs;

namespace WebStore.Identity.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> GetCustomerById(Guid id);
        Task CreateAsync(CustomerDTO customer);
        Task UpdateAsync(CustomerDTO customer);
        Task RemoveAsync(Guid id);
    }
}
