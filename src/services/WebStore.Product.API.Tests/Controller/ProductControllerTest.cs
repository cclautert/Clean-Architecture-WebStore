using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore.Domain.Interfaces;
using WebStore.Product.Application.DTOs;
using WebStore.Product.Application.Interfaces;
using WebStore.Product.Application.ViewModels;
using WebStore.Products.API.Controllers;

namespace WebStore.Product.API.Tests.Controller
{
    public class ProductControllerTest
    {
        [Fact]
        public void TeamController_Search_Get_Valid()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new ProductController(mockService.Object, mockMapper.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<ProductDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_Returns_Http_Action_Result()
        {
            // Arrange
            Guid testSessionId = new Guid();
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))!
                .ReturnsAsync((Domain.Entities.Product)null!);
            var mockService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new ProductController(mockService.Object, mockMapper.Object, mockNotifier.Object);

            // Act
            var result = await controller.Create(new ProductDTO());

            // Assert
            Assert.IsType<ActionResult<ProductViewModel>>(result);
        }

        [Fact]
        public void Index_Returns_ViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new ProductController(mockService.Object, mockMapper.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<ProductDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new ProductController(mockService.Object, mockMapper.Object, mockNotifier.Object);
            
            // Act
            var result = controller.GetAll();

            // Assert
            var viewResult = Assert.IsType<Task<IEnumerable<ProductDTO>>>(result);
            Assert.Equal(0, viewResult.Result.Count());
        }

        private List<Domain.Entities.Product> GetTestSessions()
        {
            var lstProduct = new List<Domain.Entities.Product>();
            lstProduct.Add(new Domain.Entities.Product(new Guid(), "Test One", "Test One", 1, new DateTime(2016, 7, 2)));
            lstProduct.Add(new Domain.Entities.Product(new Guid(), "Test Two", "Test Two", 1, new DateTime(2016, 7, 2)));
            
            return lstProduct;
        }
    }
}