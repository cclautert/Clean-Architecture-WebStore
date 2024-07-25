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
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;   

        public CustomerService(ICustomerRepository customerRepository,
                                 INotifier notificador,
                                 IMapper mapper) : base(notificador)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _customerRepository.GetAllAsync());
        }

        public async Task<CustomerDTO> GetCustomerById(Guid id)
        {
            return _mapper.Map<CustomerDTO>(await _customerRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            if (!RunValidation(new CustomerValidation(), customer)) return;

            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateAsync(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            if (!RunValidation(new CustomerValidation(), customer)) return;

            await _customerRepository.UpdateAsync(customer);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _customerRepository.RemoveAsync(id);
        }
    }
}
