
namespace StructuralPatterns.Adapter
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class StripeGateway
    {
        public void MakeTransaction(double value)
        {
            Console.WriteLine($"Stripe processed: ${value}");
        }
    }

    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeGateway _stripeGateway;

        public StripeAdapter(StripeGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            // Adapting the decimal to double for Stripe
            _stripeGateway.MakeTransaction((double)amount);
        }
    }

}
