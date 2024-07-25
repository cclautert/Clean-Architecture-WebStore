
namespace WebStore.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string? Description { get; private set; }

        public decimal Value { get; private set; }

        public DateTime DateRegister { get; private set; }

        public Product()
        {
            
        }

        public Product(string name, string? description, decimal value, DateTime dateRegister)
        {
            Name = name;
            Description = description;
            Value = value;
            DateRegister = dateRegister;
        }

        public Product(Guid id, string name, string? description, decimal value, DateTime dateRegister)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            DateRegister = dateRegister;
        }
    }
}
