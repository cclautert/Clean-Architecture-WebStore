using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Tests.Models
{
    public class CustomerTest
    {
        [Fact(DisplayName = "Create Customer With Success")]
        public void Create_Customer_With_Sucess()
        {
            //Arrange
            string? firstName = "First";
            string? lastName = "Last";
            string? email = "last@gmail.com";
            string? password = "123456";
            string? address = "Florida";

            //Act
            var customer = new Customer(firstName, lastName, email, address);

            //Assert
            Assert.Equal(customer.FirstName, firstName);
            Assert.Equal(customer.LastName, lastName);
            Assert.Equal(customer.Email, email);
            Assert.Equal(customer.Address, address);
        }

        public static TheoryData<string?, string?, string?, string?, bool> Cases =
            new()
            {
                { "First", "Last", "email", "address", true },
                { "First", null, "email", "address", true },
                { "First", "Last", null, "address", true },
                { "First", "Last", "email", "address", true },
                { "First", "Last", "email", null, true },
            };

        [Theory(DisplayName = "Test Model Customer With Success"), MemberData(nameof(Cases))]
        public void Test_Model_Customer_With_Sucess(string fisrtName, string lastName, string? email, string? address, bool isValid)
        {
            //Arrange

            //Act
            Customer customer = new Customer(fisrtName, lastName, email, address);

            //Assert
            Assert.Equal(isValid, ValidateModel(customer));
        }

        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
 
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
}