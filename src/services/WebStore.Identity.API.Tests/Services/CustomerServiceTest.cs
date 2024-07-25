using AutoMapper;
using Moq;
using WebStore.Domain.Entities;
using WebStore.Domain.Interfaces;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.Services;

namespace WebStore.Identity.API.Tests.Services
{
    public class CustomerServiceTest
    {
        [Fact(DisplayName = "Create Customer With Sucess")]
        public void Create_Customer_With_Sucess()
        {
            //Arrange
            string? firstName = "First";
            string? lastName = "Last";
            string? email = "last@gmail.com";
            string? address = "Florida";

            //Act
            var customer = new Customer(firstName, lastName, email, address);
            var customerRepository = new Mock<ICustomerRepository>();
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            CustomerService customerService = new CustomerService(customerRepository.Object, notifier.Object, mapper.Object);

            var customerDto = mapper.Object.Map<CustomerDTO>(customer);
            var result = customerService.CreateAsync(customerDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Update Customer With Sucess")]
        public void Update_Customer_With_Sucess()
        {
            //Arrange
            string? firstName = "First";
            string? lastName = "Last";
            string? email = "last@gmail.com";
            string? address = "Florida";

            //Act
            var customer = new Customer(firstName, lastName, email, address);
            var customerRepository = new Mock<ICustomerRepository>();
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            CustomerService customerService = new CustomerService(customerRepository.Object, notifier.Object, mapper.Object);

            var customerDto = mapper.Object.Map<CustomerDTO>(customer); 
            var result = customerService.UpdateAsync(customerDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Remove Customer With Sucess")]
        public void Remove_Customer_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            CustomerService customerService = new CustomerService(customerRepository.Object, notifier.Object, mapper.Object);

            var result = customerService.RemoveAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
    }
}