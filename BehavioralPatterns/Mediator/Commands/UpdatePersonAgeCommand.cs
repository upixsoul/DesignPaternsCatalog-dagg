using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BehavioralPatterns.Mediator.Commands
{
    public sealed record UpdateProductStockCommand(string Name, int Stock) : IRequest;

    public class UpdateProductStockCommandHandler(MediatrPatternDbContext dbContext) : IRequestHandler<UpdateProductStockCommand>
    {
        public async Task Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Products.FirstAsync(p => p.Name == request.Name, cancellationToken);
            entity.Stock = request.Stock;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
