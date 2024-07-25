using WebStore.Identity.Application.DTOs;

namespace WebStore.Identity.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> FindByEmailAsync( string email);
        Task CreateAsync(UserDTO user);
        Task UpdateAsync(UserDTO user);
        Task RemoveAsync(Guid id);
        public string GenerateToken(string id, string email);
        Task<bool> AuthenticationAsync(string email, string password);
    }
}
