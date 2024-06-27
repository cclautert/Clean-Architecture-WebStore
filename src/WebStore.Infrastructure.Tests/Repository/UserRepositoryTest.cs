using Moq;
using WebStore.Core.Entities;
using WebStore.Core.Interfaces;

namespace WebStore.Infrastructure.Tests.Repository
{
    public class UserRepositoryTest
    {
        [Fact(DisplayName = "Should Create User When Command Valid")]
        public async Task Should_Create_User_When_Command_Valid()
        {
            //Arrange
            string? Name = "Name";
            string? email = "last@gmail.com";
            string? password = "Florida";

            //Act
            var userRepository = new Mock<IUserRepository>();
            var user = new User(Name, email, password);
            var result = userRepository.Object.CreateAsync(user);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Update User When Command Valid")]
        public async Task Should_Update_User_When_Command_Valid()
        {
            //Arrange
            string? Name = "Name";
            string? email = "last@gmail.com";
            string? password = "Florida";

            //Act
            var userRepository = new Mock<IUserRepository>();
            var user = new User(Name, email, password);
            var result = userRepository.Object.UpdateAsync(user);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should Remove User When Command Valid")]
        public void Remove_User_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var userRepository = new Mock<IUserRepository>();
            var result = userRepository.Object.RemoveAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }

        [Fact(DisplayName = "Should GetById User When Command Valid")]
        public void GetById_User_With_Sucess()
        {
            //Arrange
            Guid id = new Guid();

            //Act
            var userRepository = new Mock<IUserRepository>();
            var result = userRepository.Object.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
        [Fact(DisplayName = "Should GetAll User When Command Valid")]
        public void GetAll_User_With_Sucess()
        {
            //Arrange

            //Act
            var userRepository = new Mock<IUserRepository>();
            var result = userRepository.Object.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.IsCompleted, true);
        }
    }
}