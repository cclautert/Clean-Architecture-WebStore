using MediatR;

namespace WebStore.Product.Application.Product.Queries
{
    public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
