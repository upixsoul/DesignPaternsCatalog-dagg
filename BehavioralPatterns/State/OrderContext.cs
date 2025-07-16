
namespace BehavioralPatterns.State
{
    public class OrderContext
    {
        public IOrderState State { get; set; }

        public OrderContext()
        {
            State = new PendingState(); // Initial state
        }

        public void Proceed()
        {
            State.Handle(this);
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Current Order Status: {State.GetStatus()}");
        }
    }

}
