
namespace StructuralPatterns.Decorator
{
    public interface IUserService
    {
        string GetUserData(int userId);
    }

    public class UserService : IUserService
    {
        public string GetUserData(int userId)
        {
            // Simulate fetching data from a database
            return $"User data for ID {userId}";
        }
    }

    public abstract class UserServiceDecorator : IUserService
    {
        protected readonly IUserService _userService;

        protected UserServiceDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public virtual string GetUserData(int userId)
        {
            return _userService.GetUserData(userId);
        }
    }

    public class LoggingUserService : UserServiceDecorator
    {
        public LoggingUserService(IUserService userService) : base(userService) { }

        public override string GetUserData(int userId)
        {
            // Add logging before and after the core operation
            Console.WriteLine($"[LOG] Fetching user data for ID {userId} at {DateTime.Now}");
            var result = base.GetUserData(userId);
            Console.WriteLine($"[LOG] Retrieved data: {result}");
            return result;
        }
    }

    public class CachingUserService : UserServiceDecorator
    {
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

        public CachingUserService(IUserService userService) : base(userService) { }

        public override string GetUserData(int userId)
        {
            // Check cache first
            if (_cache.TryGetValue(userId, out var cachedData))
            {
                Console.WriteLine($"[CACHE] Retrieved from cache for ID {userId}");
                return cachedData;
            }

            // If not in cache, call the core service and store the result
            var result = base.GetUserData(userId);
            _cache[userId] = result;
            Console.WriteLine($"[CACHE] Stored in cache for ID {userId}");
            return result;
        }
    }
}
