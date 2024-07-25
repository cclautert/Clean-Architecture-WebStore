using MediatR;

namespace WebStore.Product.Application.Product.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
    }
}
