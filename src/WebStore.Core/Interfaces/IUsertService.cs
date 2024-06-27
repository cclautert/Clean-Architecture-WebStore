using WebStore.Core.Entities;

namespace WebStore.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);
        public string GenerateToken(string id, string email);
        Task<bool> AuthenticationAsync(string email, string password);
    }
}
