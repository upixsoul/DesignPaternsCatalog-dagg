using BehavioralPatterns.Mediator.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BehavioralPatterns.Mediator.Queries
{
    public sealed record class ProductQueryByName(string Name) : IRequest<Product>;

    public class PersonQueryByEmailHandler(MediatrPatternDbContext dbContext) : IRequestHandler<ProductQueryByName, Product>
    {
        public async Task<Product> Handle(ProductQueryByName request, CancellationToken cancellationToken)
        {
            return await dbContext.Products.FirstAsync(p => 
                p.Name.ToUpper().Contains(request.Name.ToUpper()) ||
                p.Name.ToUpper().Equals(request.Name.ToUpper()), cancellationToken);
        }
    }
}
