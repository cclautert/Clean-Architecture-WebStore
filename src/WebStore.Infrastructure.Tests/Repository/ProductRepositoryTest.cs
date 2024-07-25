using Moq;
using WebStore.Domain.Entities;
using WebStore.Domain.Interfaces;

namespace WebStore.Infra.Data.Tests.Repository
{
    public class ProductRepositoryTest
    {
        [Fact(DisplayName = "Should Create Product When Command Valid ")]
        public async Task Should_Create_Product_When_Command_Valid()
        {
            //Arrange
            string? name = "Test";
            string? description = "Product";
            decimal value = 100;
            DateTime dateRegister = DateTime.Now;

            //Act
            Product product = new Product(name, description, value, dateRegister);
            var productRepository = new Mock<IProductRepository>();

            var result = productRepository.Object.CreateAsync(product);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Update Product When Command Valid ")]
        public async Task Should_Update_Product_When_Command_Valid()
        {
            //Arrange
            string? name = "Test";
            string? description = "Product";
            decimal value = 100;
            DateTime dateRegister = DateTime.Now;

            //Act
            Product product = new Product(name, description, value, dateRegister);
            var productRepository = new Mock<IProductRepository>();

            var result = productRepository.Object.UpdateAsync(product);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Remove Product When Command Valid ")]
        public void Remove_Product_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var productRepository = new Mock<IProductRepository>();
            var result = productRepository.Object.RemoveAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should GetById Product When Command Valid ")]
        public void GetById_Product_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var productRepository = new Mock<IProductRepository>();
            var result = productRepository.Object.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should GetAll Product When Command Valid ")]
        public void GetAll_Product_With_Sucess()
        {
            //Arrange

            //Act
            var productRepository = new Mock<IProductRepository>();
            var result = productRepository.Object.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
    }
}