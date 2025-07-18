
namespace StructuralPatterns.Facade
{
    //Subsystem Components
    //Here are the individual components of the subsystem:
    // User Validation Service
    public class UserValidationService
    {
        public bool ValidateUser(string username, string email)
        {
            Console.WriteLine($"Validating user: Username={username}, Email={email}");
            // Simple validation logic
            bool isValid = !string.IsNullOrWhiteSpace(username) && email.Contains("@");
            return isValid;
        }
    }

    // User Repository (Data Storage)
    public class UserRepository
    {
        public void SaveUser(string username, string email, string hashedPassword)
        {
            Console.WriteLine($"Saving user to database: Username={username}, Email={email}");
            // Simulate saving to a database
        }
    }

    // Email Notification Service
    public class EmailNotificationService
    {
        public void SendWelcomeEmail(string email, string username)
        {
            Console.WriteLine($"Sending welcome email to {email} for user {username}");
            // Simulate sending an email
        }
    }

    // Password Hashing Service
    public class PasswordHashingService
    {
        public string HashPassword(string password)
        {
            Console.WriteLine("Hashing password...");
            // Simulate password hashing (e.g., using BCrypt or similar in a real app)
            return "hashed_" + password;
        }
    }

    //Facade Class
    //The UserManagementFacade class provides a simplified interface to
    //register a user by coordinating the subsystem components:
    public class UserManagementFacade
    {
        private readonly UserValidationService _validationService;
        private readonly UserRepository _userRepository;
        private readonly EmailNotificationService _emailService;
        private readonly PasswordHashingService _passwordHashingService;

        public UserManagementFacade()
        {
            _validationService = new UserValidationService();
            _userRepository = new UserRepository();
            _emailService = new EmailNotificationService();
            _passwordHashingService = new PasswordHashingService();
        }

        public string RegisterUser(string username, string email, string password)
        {
            // Step 1: Validate user input
            if (!_validationService.ValidateUser(username, email))
            {
                return "Registration failed: Invalid username or email.";
            }

            // Step 2: Hash the password
            string hashedPassword = _passwordHashingService.HashPassword(password);

            // Step 3: Save user to the database
            _userRepository.SaveUser(username, email, hashedPassword);

            // Step 4: Send welcome email
            _emailService.SendWelcomeEmail(email, username);

            return $"User {username} registered successfully!";
        }
    }
}
