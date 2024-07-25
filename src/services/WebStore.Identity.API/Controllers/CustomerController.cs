using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Interfaces;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.Interfaces;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.API.Controllers
{
    [Route("api/customer")]
    public class CustomerController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper,
                                  ICustomerService customerService,
                                  INotifier notificator) : base(notificator)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _customerService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDTO>> GetById(Guid id)
        {
            var customer = await GetCustomerById(id);

            if (customer == null) return NotFound();

            return customer;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CustomerViewModel>> Create(CustomerDTO customerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _customerService.CreateAsync(_mapper.Map<CustomerDTO>(customerViewModel));

            return CustomResponse(HttpStatusCode.Created, customerViewModel);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<CustomerViewModel>> Update(Guid id, CustomerDTO customerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _customerService.UpdateAsync(_mapper.Map<CustomerDTO>(customerViewModel));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<CustomerViewModel>> Delete(Guid id)
        {
            await _customerService.RemoveAsync(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }
        private async Task<CustomerDTO> GetCustomerById(Guid id)
        {
            return _mapper.Map<CustomerDTO>(await _customerService.GetCustomerById(id));
        }
    }
}