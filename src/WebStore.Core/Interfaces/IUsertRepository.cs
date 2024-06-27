using WebStore.Core.Entities;

namespace WebStore.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> PasswordSignInAsync(string email, string password);

        Task<bool> AuthenticationAsync(string email, string password);
        public string GenerateToken(string id, string email);
    }
}
