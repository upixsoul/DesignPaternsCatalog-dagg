
namespace StructuralPatterns.Bridge
{
    //This is the interface for the implementation layer (the "bridge").
    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    //Create Concrete Implementations
    //These are the concrete classes that implement the IMessageSender interface for different channels.
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    public class SMSSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    //Define the Abstraction
    //This is the abstraction that clients interact with. It holds a reference to an IMessageSender (the bridge).
    public abstract class Message
    {
        protected IMessageSender _messageSender;

        protected Message(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Send(string content);
    }

    //Create Refined Abstractions
    //These are the specific message types that extend the abstraction and define how the message is formatted or processed.
    public class StandardMessage : Message
    {
        public StandardMessage(IMessageSender messageSender) : base(messageSender) { }

        public override void Send(string content)
        {
            string formattedMessage = $"Standard Message: {content}";
            _messageSender.SendMessage(formattedMessage);
        }
    }

    public class UrgentMessage : Message
    {
        public UrgentMessage(IMessageSender messageSender) : base(messageSender) { }

        public override void Send(string content)
        {
            string formattedMessage = $"[URGENT] {content}";
            _messageSender.SendMessage(formattedMessage);
        }
    }
}
