
namespace WebStore.Domain.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string? Address { get; private set; }

        public Customer()
        {
                
        }
        public Customer(string firstName, string lastName, string email, string? address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public Customer(Guid id, string firstName, string lastName, string email, string? address)
        {
            Id = id;    
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }
    }
}
