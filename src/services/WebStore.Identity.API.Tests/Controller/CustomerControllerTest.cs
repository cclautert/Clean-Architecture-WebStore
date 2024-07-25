using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore.Domain.Entities;
using WebStore.Domain.Interfaces;
using WebStore.Identity.API.Controllers;
using WebStore.Identity.Application.DTOs;
using WebStore.Identity.Application.Interfaces;
using WebStore.Identity.Application.ViewModels;

namespace WebStore.Identity.API.Tests.Controller
{
    public class CustomerControllerTest
    {
        [Fact]
        public void TeamController_Search_Get_Valid()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new CustomerController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<CustomerDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_Returns_Http_Action_Result()
        {
            // Arrange
            Guid testSessionId = new Guid();
            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))!
                .ReturnsAsync((Customer)null!);
            var mockService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new CustomerController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = await controller.Create(new CustomerDTO());

            // Assert
            Assert.IsType<ActionResult<CustomerViewModel>>(result);
        }

        [Fact]
        public void Index_Returns_ViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new CustomerController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<CustomerDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new CustomerController(mockMapper.Object, mockService.Object, mockNotifier.Object);
            
            // Act
            var result = controller.GetAll();

            // Assert
            var viewResult = Assert.IsType<Task<IEnumerable<CustomerDTO>>>(result);
            Assert.Equal(0, viewResult.Result.Count());
        }

        private List<Customer> GetTestSessions()
        {
            var lstCustomer = new List<Customer>();
            lstCustomer.Add(new Customer(new Guid(), "Test one", "Test one", "Test one", "Test one"));
            lstCustomer.Add(new Customer(new Guid(), "Test two", "Test two", "Test two", "Test two"));
            return lstCustomer;
        }
    }
}