using MediatR;

namespace WebStore.Product.Application.Product.Commands
{
    public abstract class ProductCommand : IRequest<Domain.Entities.Product>
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Value { get; set; }

        public DateTime DateRegister { get; set; }
    }
}
