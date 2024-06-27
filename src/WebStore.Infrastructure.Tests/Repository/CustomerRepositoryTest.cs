using Moq;
using WebStore.Core.Entities;
using WebStore.Core.Interfaces;

namespace WebStore.Infrastructure.Tests.Repository
{
    public class CustomerRepositoryTest
    {
        [Fact(DisplayName = "Should Create Customer When Command Valid")]
        public async Task Should_Create_Customer_When_Command_Valid()
        {
            //Arrange
            string? firstName = "First";
            string? lastName = "Last";
            string? email = "last@gmail.com";
            string? address = "Florida";

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var customer = new Customer(firstName, lastName, email, address);
            var result = customerRepository.Object.CreateAsync(customer);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Update Customer When Command Valid")]
        public async Task Should_Update_Customer_When_Command_Valid()
        {
            //Arrange
            string? firstName = "First";
            string? lastName = "Last";
            string? email = "last@gmail.com";
            string? address = "Florida";

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var customer = new Customer(firstName, lastName, email, address);
            var result = customerRepository.Object.UpdateAsync(customer);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Remove Customer When Command Valid")]
        public void Remove_Customer_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var result = customerRepository.Object.RemoveAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should GetById Customer When Command Valid")]
        public void GetById_Customer_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var result = customerRepository.Object.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should GetAll Customer When Command Valid")]
        public void GetAll_Customer_With_Sucess()
        {
            //Arrange

            //Act
            var customerRepository = new Mock<ICustomerRepository>();
            var result = customerRepository.Object.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
    }
}