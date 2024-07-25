using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Interfaces;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.Interfaces;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.API.Controllers
{
    [Route("api/user")]
    public class UserController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper,
                                  IUserService userService,
                                  INotifier notificator) : base(notificator)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register(UserDTO userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _userService.FindByEmailAsync(userViewModel.Email);
            if (usuario?.Email != null)
            {
                NotifyError("email exists!");
                return CustomResponse();
            }

            await _userService.CreateAsync(_mapper.Map<UserDTO>(userViewModel));

            var authToken =  _userService.GenerateToken(userViewModel.Email, userViewModel.Password);

            return new UserToken
            {
                Token = authToken
            };
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<UserToken>> LogIn(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _userService.AuthenticationAsync(userViewModel.Email, userViewModel.Password);

            if (result)
            {
                var authToken =  _userService.GenerateToken(userViewModel.Email, userViewModel.Password);

                return new UserToken
                {
                    Token = authToken
                };
            }

            NotifyError("Incorrect username or password");
            return CustomResponse();
        }
    }
}