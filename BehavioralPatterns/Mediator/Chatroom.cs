using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator
{
    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(
            string from, string to, string message);
    }
    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();
        public override void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }
        public override void Send(string from, string to, string message)
        {
            Participant participant = participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    public class Participant
    {
        Chatroom chatroom;
        string name;
        // Constructor
        public Participant(string name)
        {
            this.name = name;
        }
        // Gets participant name
        public string Name
        {
            get { return name; }
        }
        // Gets chatroom
        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }
        // Sends message to given participant
        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }
        // Receives message from given participant
        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }
    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    public class Beatle : Participant
    {
        // Constructor
        public Beatle(string name)
            : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }
    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    public class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
            : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
