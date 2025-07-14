using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.ChainOfResponsibility
{
    // Abstract handler class
    public abstract class Approver
    {
        protected Approver _nextApprover;

        // Set the next handler in the chain
        public void SetNext(Approver nextApprover)
        {
            _nextApprover = nextApprover;
        }

        // Handle the request (to be implemented by concrete handlers)
        public abstract void ProcessRequest(PurchaseRequest request);
    }

    // Concrete request class
    public class PurchaseRequest
    {
        public int RequestId { get; }
        public double Amount { get; }
        public string Purpose { get; }

        public PurchaseRequest(int requestId, double amount, string purpose)
        {
            RequestId = requestId;
            Amount = amount;
            Purpose = purpose;
        }
    }

    // Concrete handler: Manager
    public class Manager : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 1000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request #{request.RequestId} for {request.Amount:C} - {request.Purpose}");
            }
            else if (_nextApprover != null)
            {
                Console.WriteLine($"{this.GetType().Name} cannot approve request #{request.RequestId}. Passing to next level.");
                _nextApprover.ProcessRequest(request);
            }
            else
            {
                Console.WriteLine($"Request #{request.RequestId} for {request.Amount:C} cannot be approved by anyone.");
            }
        }
    }

    // Concrete handler: Director
    public class Director : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 5000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request #{request.RequestId} for {request.Amount:C} - {request.Purpose}");
            }
            else if (_nextApprover != null)
            {
                Console.WriteLine($"{this.GetType().Name} cannot approve request #{request.RequestId}. Passing to next level.");
                _nextApprover.ProcessRequest(request);
            }
            else
            {
                Console.WriteLine($"Request #{request.RequestId} for {request.Amount:C} cannot be approved by anyone.");
            }
        }
    }

    // Concrete handler: CEO
    public class CEO : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 10000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request #{request.RequestId} for {request.Amount:C} - {request.Purpose}");
            }
            else
            {
                Console.WriteLine($"Request #{request.RequestId} for {request.Amount:C} is too large and cannot be approved.");
            }
        }
    }
}
