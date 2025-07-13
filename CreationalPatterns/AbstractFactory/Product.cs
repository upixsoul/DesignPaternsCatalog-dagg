
namespace CreationalPatterns.AbstractFactory
{
    public class Product
    {
        private readonly string _type;

        private Product(string type)
        {
            _type = type;
        }

        // Static Factory Methods
        public static Product CreateStandardProduct() => new Product("Standard");
        public static Product CreatePremiumProduct() => new Product("Premium");

        public string GetDescription() => $"Product {_type}";
    }
}
