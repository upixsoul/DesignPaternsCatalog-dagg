
namespace CreationalPatterns.FactoryMethod
{
    enum PaymentMethod
    {
        PayPal,
        Stripe,
        BankTransfer
    }
    //Product interface (defines common behavior for payment processors)
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
        string GetProviderName();
    }

    //Specific products (specific implementations of payment processors)
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} through PayPal.");
            return true;
        }

        public string GetProviderName() => "PayPal";
    }

    public class StripeProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} through Stripe.");
            return true;
        }

        public string GetProviderName() => "Stripe";
    }

    public class BankTransferProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} through bank transfer.");
            return true;
        }

        public string GetProviderName() => "Bank Transfer";
    }

    //Abstract creator class (defines the Factory Method)
    public abstract class PaymentProcessorFactory
    {
        //Factory Method abstract
        public abstract IPaymentProcessor CreatePaymentProcessor();

        //Method that the Factory Method uses to process a payment
        public bool Process(decimal amount)
        {
            IPaymentProcessor processor = CreatePaymentProcessor();
            Console.WriteLine($"Using provider: {processor.GetProviderName()}");
            return processor.ProcessPayment(amount);
        }
    }

    //Concrete creators (implement the Factory Method)
    public class PayPalProcessorFactory : PaymentProcessorFactory
    {
        public override IPaymentProcessor CreatePaymentProcessor() => new PayPalProcessor();
    }

    public class StripeProcessorFactory : PaymentProcessorFactory
    {
        public override IPaymentProcessor CreatePaymentProcessor() => new StripeProcessor();
    }

    public class BankTransferProcessorFactory : PaymentProcessorFactory
    {
        public override IPaymentProcessor CreatePaymentProcessor() => new BankTransferProcessor();
    }
}
