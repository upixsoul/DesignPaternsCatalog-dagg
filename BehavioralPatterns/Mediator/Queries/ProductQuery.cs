using BehavioralPatterns.Mediator.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BehavioralPatterns.Mediator.Queries
{
    public sealed record ProductQuery : IRequest<IReadOnlyList<Product>>;

    public class ProductQueryHandler(MediatrPatternDbContext dbContext) : IRequestHandler<ProductQuery, IReadOnlyList<Product>>
    {
        public async Task<IReadOnlyList<Product>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
