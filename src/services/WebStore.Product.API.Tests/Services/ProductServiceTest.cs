using AutoMapper;
using MediatR;
using Moq;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Interfaces;
using WebStore.Product.Application.Services;

namespace WebStore.Product.API.Tests.Services
{
    public class ProductServiceTest
    {
        [Fact]
        public void Create_Product_With_Sucess()
        {
            //Arrange
            string? name = "Test";
            string? description = "Product";
            decimal value = 100;
            DateTime dateRegister = DateTime.Now;

            //Act
            Domain.Entities.Product product = new Domain.Entities.Product(name, description, value, dateRegister);
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            var mediator = new Mock<IMediator>();
            ProductService productService = new ProductService(notifier.Object, mapper.Object, mediator.Object);

            var productDto = mapper.Object.Map<ProductDTO>(product);
            var result = productService.CreateAsync(productDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact]
        public void Update_Customer_With_Sucess()
        {
            //Arrange
            string? name = "Test";
            string? description = "Product";
            decimal value = 100;
            DateTime dateRegister = DateTime.Now;

            //Act
            Domain.Entities.Product product = new Domain.Entities.Product(name, description, value, dateRegister);
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            var mediator = new Mock<IMediator>();
            ProductService productService = new ProductService(notifier.Object, mapper.Object, mediator.Object);

            var productDto = mapper.Object.Map<ProductDTO>(product);
            var result = productService.UpdateAsync(productDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact]
        public void Remove_Customer_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var notifier = new Mock<INotifier>();
            var mapper = new Mock<IMapper>();
            var mediator = new Mock<IMediator>();
            ProductService productService = new ProductService(notifier.Object, mapper.Object, mediator.Object);

            var result = productService.RemoveAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
    }
}