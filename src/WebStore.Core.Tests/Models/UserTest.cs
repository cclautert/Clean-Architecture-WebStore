using System.ComponentModel.DataAnnotations;
using WebStore.Core.Entities;

namespace WebStore.Core.Tests.Models
{
    public class UserTest
    {
        [Fact(DisplayName = "Create User With Success")]
        public void Create_User_With_Success()
        {
            //Arrange
            string? Name = "First";
            string? email = "last@gmail.com";
            string? password = "123456";

            //Act
            var user = new User(Name, email, password);

            //Assert
            Assert.Equal(user.Name, Name);
            Assert.Equal(user.Email, email);
            Assert.Equal(user.Email, email);
            Assert.Equal(user.Password, password);
        }

        public static TheoryData<string?, string?, string?, bool> Cases =
            new()
            {
                { "First", "email", "address", true },
                { "First", "email", "address", true },
                { "First",  null,   "address", true },
                { "First", "email", "address", true },
                { "First", "email",  null,     true },
            };

        [Theory(DisplayName = "Test Model User With Success"), MemberData(nameof(Cases))]
        public void Test_Model_User_With_Sucess(string Name, string? email, string? password, bool isValid)
        {
            //Arrange

            //Act
            User user = new User(Name, email, password);

            //Assert
            Assert.Equal(isValid, ValidateModel(user));
        }

        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
 
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
}