
namespace StructuralPatterns.Decorator
{
    //Step 1: Define the Interface
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    //Step 2: Concrete Component (Core Implementation)This is the base service that sends notifications via email.
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // Simulate sending an email
            Console.WriteLine($"[EMAIL] Sending to {recipient}: {message}");
        }
    }

    //Step 3: Abstract Decorator Class
    //The decorator implements the same interface and holds a reference to an INotificationService object,
    //allowing it to wrap the core service.
    public abstract class NotificationServiceDecorator : INotificationService
    {
        protected readonly INotificationService _notificationService;

        protected NotificationServiceDecorator(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public virtual void SendNotification(string recipient, string message)
        {
            _notificationService.SendNotification(recipient, message);
        }
    }

    //Step 4: Concrete Decorators
    //Let's create two decorators: one for sending notifications via SMS and one for logging notifications.SMS Decorator
    public class SmsNotificationService : NotificationServiceDecorator
    {
        public SmsNotificationService(INotificationService notificationService) : base(notificationService) { }

        public override void SendNotification(string recipient, string message)
        {
            // Call the core service (or other decorators)
            base.SendNotification(recipient, message);

            // Add SMS functionality
            Console.WriteLine($"[SMS] Sending to {recipient}: {message}");
        }
    }

    public class LoggingNotificationService : NotificationServiceDecorator
    {
        public LoggingNotificationService(INotificationService notificationService) : base(notificationService) { }

        public override void SendNotification(string recipient, string message)
        {
            // Log before sending
            Console.WriteLine($"[LOG] Notification to {recipient} at {DateTime.Now}: {message}");

            // Call the core service (or other decorators)
            base.SendNotification(recipient, message);

            // Log after sending
            Console.WriteLine($"[LOG] Notification sent successfully to {recipient}");
        }
    }
}
