
namespace BehavioralPatterns.State
{
    // State interface
    public interface IOrderState
    {
        void Handle(OrderContext context);
        string GetStatus();
    }

    // Concrete States
    public class PendingState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            context.State = new ShippedState();
        }

        public string GetStatus() => "Pending";
    }

    public class ShippedState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            context.State = new DeliveredState();
        }

        public string GetStatus() => "Shipped";
    }

    public class DeliveredState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            Console.WriteLine("Order is already delivered. No further transitions.");
        }

        public string GetStatus() => "Delivered";
    }

}
