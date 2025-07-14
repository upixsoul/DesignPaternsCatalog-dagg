using CreationalPatterns.AbstractFactory;
using CreationalPatterns.Builder;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.Prototype;
using CreationalPatterns.Singleton;

namespace CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG Patterns Catalog");
            Console.WriteLine("This catalog contains examples of various creational design patterns.");

            #region Singleton
            Console.WriteLine("Testing Singleton");
            var singleton = Singleton.Singleton.Instance;
            var nextSingleton = Singleton.Singleton.Instance;
            Console.WriteLine($"singleton: {singleton.Id}");
            Console.WriteLine($"nextSingleton: {nextSingleton.Id}");
            #endregion

            #region Builder
            Console.WriteLine();
            Console.WriteLine("Testing Builder");
            var dog = new Pet.Builder()
                .WithType("Dog")
                .WithNickname("Rex")
                .WithOfficialName("Louis Charles Bryan the Third")
                .WithFatherName("Lucky")
                .WithMotherName("Tina")
                .WithBreedingCompanyName("Happy Paws").Build();
            Console.WriteLine($"builder dog: type {dog.Type}, nickname {dog.Nickname}, " +
                              $"official name {dog.OfficialName}, father name {dog.FatherName}, " +
                              $"mother name {dog.MotherName}, breeding company name {dog.BreedingCompanyName}");
            #endregion

            #region FactoryMethod
            Console.WriteLine();
            Console.WriteLine("Testing Factory Method");
            var requestAmount = 100.00m; // Example amount for payment processing
            PaymentMethod paymentMethod = PaymentMethod.PayPal;
            PaymentProcessorFactory factory = paymentMethod switch
            {
                PaymentMethod.PayPal => new PayPalProcessorFactory(),
                PaymentMethod.Stripe => new StripeProcessorFactory(),
                PaymentMethod.BankTransfer => new BankTransferProcessorFactory(),
                _ => throw new ArgumentException("Payment method not supported")
            };

            //Process payment using the factory
            bool result = factory.Process(requestAmount);
            string resultMessage = result ? "Payment processed successfully" : "Error processing payment";
            Console.WriteLine($"Factory Method Result Message: {resultMessage}");
            #endregion

            #region AbstractFactory
            Console.WriteLine();
            Console.WriteLine("Testing Abstract Factory Method");
            var bankAccount = BankAccount.ForChildren();
            var otherBankAccount = BankAccount.Regular();
            Console.WriteLine($"Bank Account for Children: Max Withdrawal Sum = {bankAccount.GetMaxWithdrawalSum()}");
            Console.WriteLine($"Regular Bank Account: Max Withdrawal Sum = {otherBankAccount.GetMaxWithdrawalSum()}");

            var standardProduct = Product.CreateStandardProduct();
            Console.WriteLine(standardProduct.GetDescription()); // Output: Product Standard
            var premiumProduct = Product.CreatePremiumProduct();
            Console.WriteLine(premiumProduct.GetDescription()); // Output: Product Premium
            #endregion

            #region Prototype
            Console.WriteLine();
            Console.WriteLine("Testing Prototype Method");

            //Create base configuration (prototype)
            var metadata = new Dictionary<string, string>
            {
                { "Author", "System" },
                { "Version", "1.0" }
            };
            IReportConfig baseConfig = new ReportConfig("Report Base", "PDF", metadata);

            //Clone and customize
            var config1 = (IReportConfig)baseConfig.Clone();
            config1.Title = "Annual Financial Report";
            config1.Metadata.Add("Department", "Finance");

            var config2 = (IReportConfig)baseConfig.Clone();
            config2.Title = "Monthly Report";
            config2.Format = "Excel";
            config2.Metadata["Version"] = "2.0";

            //Show settings
            Console.WriteLine("Configuration Base:");
            baseConfig.DisplayConfig();
            Console.WriteLine("\nConfiguration 1 (Cloned and Modified):");
            config1.DisplayConfig();
            Console.WriteLine("\nConfiguration 2 (Cloned and Modified):");
            config2.DisplayConfig();
            #endregion
        }
    }
}
