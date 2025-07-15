using BehavioralPatterns.Mediator.Commands;
using BehavioralPatterns.Mediator.Notifications;
using BehavioralPatterns.Mediator.Queries;
using MediatR;

namespace BehavioralPatterns.Mediator
{
    public class MicrosoftImplementation
    {
        private IMediator _mediator;

        public MicrosoftImplementation(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Apply()
        {
            var products = await _mediator.Send(new ProductQuery());
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Stock: {product.Stock}");
            }
            var productByName = await _mediator.Send(new ProductQueryByName("Product 2"));
            Console.WriteLine($"Product by name: {productByName.Name}, Stock: {productByName.Stock}");

            await _mediator.Send(new UpdateProductStockCommand("Product 2", 55));

            var productByName2 = await _mediator.Send(new ProductQueryByName("Product 2"));
            await _mediator.Publish(new StockChangedNotification(Name: "Product 2"));
            Console.WriteLine($"Product by name: {productByName2.Name}, Stock: {productByName2.Stock}");

            await _mediator.Send(new UpdateProductStockCommand("Product 2", 50));
            productByName2 = await _mediator.Send(new ProductQueryByName("Product 2"));
            Console.WriteLine($"Product by name: {productByName2.Name}, Stock: {productByName2.Stock}");
        }
    }
}
