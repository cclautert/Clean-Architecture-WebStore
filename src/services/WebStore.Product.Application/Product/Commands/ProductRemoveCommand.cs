using MediatR;

namespace WebStore.Product.Application.Product.Commands
{
    public class ProductRemoveCommand : IRequest<Domain.Entities.Product>
    {
        public Guid Id { get; set; }

        public ProductRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
