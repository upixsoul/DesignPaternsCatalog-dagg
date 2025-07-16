using StructuralPatterns.Adapter;

namespace StructuralPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG Patterns Catalog");
            Console.WriteLine("This catalog contains examples of various structural design patterns.");

            #region Adapter
            Console.WriteLine("Testing Adapter Pattern");
            IPaymentProcessor paymentProcessor = new StripeAdapter(new StripeGateway());
            paymentProcessor.ProcessPayment(99.99m);
            #endregion

        }
    }
}
