using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Validations;
using WebStore.Domain.Interfaces;
using WebStore.Domain.Services;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.Interfaces;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userepository, 
                           INotifier notificador,
                           IMapper mapper) : base(notificador)
        {
            _userRepository = userepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDTO> FindByEmailAsync(string email)
        {
            return _mapper.Map<UserDTO>(await _userRepository.FindByEmailAsync(email));
        }

        public async Task CreateAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);

            if (!RunValidation(new UserValidation(), user)) return;

            if (user.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                byte[] passwordSalt = hmac.Key;

                user.UpdatePassword(passwordHash, passwordSalt);
            }

            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);

            if (!RunValidation(new UserValidation(), user)) return;

            if (user.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                byte[] passwordSalt = hmac.Key;

                user.UpdatePassword(passwordHash, passwordSalt);
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> AuthenticationAsync(string email, string password)
        {
            if (password != null)
            {
                User user = await _userRepository.FindByEmailAsync(email);

                if (user.PasswordHSalt != null)
                {
                    using var hmac = new HMACSHA512(user.PasswordHSalt);
                    var computedHas = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHas.Length; i++)
                    {
                        if (computedHas[i] != user.PasswordHash[i]) return false;
                    }
                    return true;
                }
            }

            return false;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _userRepository.RemoveAsync(id);
        }

        public string GenerateToken(string id, string email)
        {
            return _userRepository.GenerateToken(id, email);
        }
    }
}
