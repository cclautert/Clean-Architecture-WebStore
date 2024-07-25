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
    public class UserControllerTest
    {
        [Fact]
        public void TeamController_Search_Get_Valid()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new UserController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<UserDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_Returns_Http_Action_Result()
        {
            // Arrange
            Guid testSessionId = new Guid();
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))!
                .ReturnsAsync((User)null!);
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new UserController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = await controller.Register(new UserDTO());

            // Assert
            Assert.IsType<ActionResult<UserToken>>(result);
        }

        [Fact]
        public void Index_Returns_ViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new UserController(mockMapper.Object, mockService.Object, mockNotifier.Object);

            // Act
            var result = controller.GetAll() as Task<IEnumerable<UserDTO>>;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();
            var mockNotifier = new Mock<INotifier>();
            var controller = new UserController(mockMapper.Object, mockService.Object, mockNotifier.Object);
            
            // Act
            var result = controller.GetAll();

            // Assert
            var viewResult = Assert.IsType<Task<IEnumerable<UserDTO>>>(result);
            Assert.Equal(0, viewResult.Result.Count());
        }

        private List<User> GetTestSessions()
        {
            var lstUser = new List<User>();
            lstUser.Add(new User("Test One", "Test One", "Test One"));
            lstUser.Add(new User("Test Two", "Test Two", "Test Two"));

            return lstUser;
        }
    }
}