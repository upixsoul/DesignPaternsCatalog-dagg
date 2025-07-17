using StructuralPatterns.Adapter;
using StructuralPatterns.Bridge;
using StructuralPatterns.Composite;
using StructuralPatterns.Decorator;
using Directory = StructuralPatterns.Composite.Directory;
using File = StructuralPatterns.Composite.File;

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

            #region Bridge
            Console.WriteLine();
            Console.WriteLine("Testing Bridge Pattern");
            // Create implementation instances
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SMSSender();

            // Create messages with different senders
            Message standardEmail = new StandardMessage(emailSender);
            Message urgentSMS = new UrgentMessage(smsSender);
            Message urgentEmail = new UrgentMessage(emailSender);

            // Send messages
            standardEmail.Send("Hello, this is a standard message!");
            urgentSMS.Send("This is an urgent alert!");
            urgentEmail.Send("This is an urgent email!");
            #endregion

            #region Composite
            Console.WriteLine();
            Console.WriteLine("Testing Composite Pattern");
            // Create files (leaf nodes)
            FileSystemComponent file1 = new File("Document.txt", 100);
            FileSystemComponent file2 = new File("Image.jpg", 200);
            FileSystemComponent file3 = new File("Video.mp4", 500);

            // Create directories (composite nodes)
            Directory root = new Directory("Root");
            Directory documents = new Directory("Documents");
            Directory media = new Directory("Media");

            // Build hierarchy
            root.Add(documents);
            root.Add(media);
            documents.Add(file1);
            media.Add(file2);
            media.Add(file3);

            // Display the structure and calculate sizes
            root.Display("*");

            // Output total size of Root directory
            Console.WriteLine($"\nTotal size of Root: {root.GetSize()} KB");

            Console.WriteLine();
            Console.WriteLine("Another Example");
            // Create individual menu items (leaf nodes)
            MenuComponent burger = new MenuItem("Cheeseburger", 8.99m);
            MenuComponent fries = new MenuItem("French Fries", 3.49m);
            MenuComponent soda = new MenuItem("Cola", 1.99m);
            MenuComponent salad = new MenuItem("Caesar Salad", 6.49m);

            // Create menus (composite nodes)
            Menu mainMenu = new Menu("Main Menu");
            Menu lunchMenu = new Menu("Lunch Specials");
            Menu drinksMenu = new Menu("Drinks");

            // Build hierarchy
            mainMenu.Add(lunchMenu);
            mainMenu.Add(salad);
            mainMenu.Add(drinksMenu);
            lunchMenu.Add(burger);
            lunchMenu.Add(fries);
            drinksMenu.Add(soda);

            // Display the menu structure and calculate total price
            mainMenu.Display("*");

            // Output total price of Main Menu
            Console.WriteLine($"\nTotal price of Main Menu: ${mainMenu.GetPrice():F2}");
            #endregion

            #region Decorator
            Console.WriteLine();
            Console.WriteLine("Testing Decorator Pattern");
            // Create the core service
            IUserService userService = new UserService();

            // Wrap with logging
            userService = new LoggingUserService(userService);

            // Wrap with caching
            userService = new CachingUserService(userService);

            // Test the decorated service
            Console.WriteLine("First call:");
            var data = userService.GetUserData(1); // Logs and caches
            Console.WriteLine($"Result: {data}\n");

            Console.WriteLine("Second call (should hit cache):");
            data = userService.GetUserData(1); // Retrieves from cache, logs
            Console.WriteLine($"Result: {data}");


            Console.WriteLine();
            Console.WriteLine("Another Example");
            // Create the core email notification service
            INotificationService notificationService = new EmailNotificationService();

            // Wrap with logging
            notificationService = new LoggingNotificationService(notificationService);

            // Wrap with SMS
            notificationService = new SmsNotificationService(notificationService);

            // Test the decorated service
            notificationService.SendNotification("user@example.com", "Hello, this is a test notification!");
            #endregion
        }
    }
}
