using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Proxy
{
    // Subject interface defining the contract
    public interface IProductService
    {
        string GetProductDetails(int productId);
    }

    // Real Subject: The actual service that retrieves product details
    public class ProductService : IProductService
    {
        public string GetProductDetails(int productId)
        {
            // Simulate expensive database query
            Console.WriteLine($"Fetching product details for ID {productId} from database...");
            return $"Product details for ID {productId}";
        }
    }

    // Proxy: Caches product details to avoid redundant database calls
    public class CachingProductServiceProxy : IProductService
    {
        private readonly ProductService _realService;
        private readonly ConcurrentDictionary<int, string> _cache;

        public CachingProductServiceProxy()
        {
            _realService = new ProductService();
            _cache = new ConcurrentDictionary<int, string>();
        }

        public string GetProductDetails(int productId)
        {
            // Check if data is in cache
            if (_cache.TryGetValue(productId, out string cachedDetails))
            {
                Console.WriteLine($"Returning cached product details for ID {productId}");
                return cachedDetails;
            }

            // If not in cache, fetch from real service and cache the result
            string details = _realService.GetProductDetails(productId);
            _cache.TryAdd(productId, details);
            return details;
        }
    }
}
