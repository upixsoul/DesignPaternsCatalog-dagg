using BehavioralPatterns.ChainOfResponsibility;
using BehavioralPatterns.Command;
using BehavioralPatterns.Interpreter;
using BehavioralPatterns.Iterator;
using BehavioralPatterns.Mediator;
using BehavioralPatterns.Mediator.Notifications;
using BehavioralPatterns.Memento;
using BehavioralPatterns.Observer;
using BehavioralPatterns.Visitor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BehavioralPatterns
{
    

    public class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG Patterns Catalog");
            Console.WriteLine("This catalog contains examples of various creational design patterns.");

            #region Visitor
            Console.WriteLine("Testing Visitor Pattern");
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Square());
            shapes.Add(new Triangle());

            var areaCalculator = new AreaCalculator();
            foreach(Shape shape in shapes)
            {
                shape.accept(areaCalculator);
            }
            Console.WriteLine("Total area: " + areaCalculator.getTotalArea());

            var perimeterCalculator = new PerimeterCalculator();
            foreach (Shape shape in shapes)
            {
                shape.accept(perimeterCalculator);
            }
            Console.WriteLine("Total perimeter: " + perimeterCalculator.getTotalPerimeter());
            #endregion

            #region ChainOfResponsibility
            Console.WriteLine();
            Console.WriteLine("Testing Chain of Responsibility Pattern");
            // Set up the chain: Manager -> Director -> CEO
            Approver manager = new Manager();
            Approver director = new Director();
            Approver ceo = new CEO();

            manager.SetNext(director);
            director.SetNext(ceo);

            // Create some purchase requests
            var requests = new List<PurchaseRequest>
            {
                new PurchaseRequest(1, 500, "Office supplies"),
                new PurchaseRequest(2, 3000, "New laptops"),
                new PurchaseRequest(3, 7000, "Server upgrade"),
                new PurchaseRequest(4, 15000, "Company car")
            };

            // Process each request
            foreach (var request in requests)
            {
                Console.WriteLine($"\nProcessing request #{request.RequestId} for {request.Amount:C}");
                manager.ProcessRequest(request);
            }
            #endregion

            #region Command
            Console.WriteLine();
            Console.WriteLine("Testing Command Pattern");
            // Create the receiver
            TextEditor editor = new TextEditor();

            // Create the invoker
            TextEditorInvoker invoker = new TextEditorInvoker();

            // Create commands
            ICommand typeHello = new TypeTextCommand(editor, "Hello, ");
            ICommand typeWorld = new TypeTextCommand(editor, "World!");

            // Execute commands
            invoker.ExecuteCommand(typeHello); // Output: Current text: Hello, 
            invoker.ExecuteCommand(typeWorld); // Output: Current text: Hello, World!

            // Undo commands
            invoker.UndoCommand(); // Output: Current text after undo: Hello, 
            invoker.UndoCommand(); // Output: Current text after undo: 
            invoker.UndoCommand(); // Output: Nothing to undo.
            #endregion

            #region Interpreter
            Console.WriteLine();
            Console.WriteLine("Testing Command Pattern");

            // Create a user context
            var user = new UserContext { Role = "admin", Department = "HR" };

            // Define rule: Allow access if user is admin OR in IT department
            IExpression rule = new OrExpression(
                new RoleExpression("admin"),
                new DepartmentExpression("IT")
            );

            // Check access
            var accessControl = new AccessControlService();
            bool hasAccess = accessControl.HasAccess(user, rule);
            Console.WriteLine($"User has access: {hasAccess}"); // Output: User has access: True

            // Another rule: Allow access if user is admin AND in IT department
            rule = new AndExpression(
                new RoleExpression("admin"),
                new DepartmentExpression("IT")
            );
            hasAccess = accessControl.HasAccess(user, rule);
            Console.WriteLine($"User has access: {hasAccess}"); // Output: User has access: False
            #endregion

            #region Iterator
            Console.WriteLine();
            Console.WriteLine("Testing Iterator Pattern");
            Console.WriteLine("With Iterator");
            var somePeople = new People();
            somePeople.Add(new Person { Name = "Alice", Age = 30 });
            somePeople.Add(new Person { Name = "Bob", Age = 25 });
            somePeople.Add(new Person { Name = "Charlie", Age = 35 });
            somePeople.Add(new Person { Name = "Diana", Age = 28 });

            foreach (Person person in somePeople)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            Console.WriteLine("\nNow With IEnumerable");
            var words = new[] { "a", "little", "duck" };
            var wordsCollection = new WordsCollection(words);
            foreach (var word in wordsCollection)
            {
                Console.WriteLine(word);
            }
            #endregion

            #region Mediator
            Console.WriteLine();
            Console.WriteLine("Testing Mediator Pattern");

            var m = new ConcreteMediator();
            var c1 = new ConcreteColleague1(m);
            var c2 = new ConcreteColleague2(m);
            m.Colleague1 = c1;
            m.Colleague2 = c2;
            c1.Send("How are you?");
            c2.Send("Fine, thanks");

            Console.WriteLine();
            Console.WriteLine("Other Example");
            // Create chatroom
            Chatroom chatroom = new Chatroom();
            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");
            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);
            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            Console.WriteLine();
            Console.WriteLine("Now Microsoft Approach");

            var services = new ServiceCollection();
            services.AddLogging(logging => logging.AddConsole());
            services.AddSingleton<AddLogWhenStockIsChangedNotificationHandler>();
            services.AddDbContextPool<MediatrPatternDbContext>(options =>
                options.UseSqlServer("Data Source=ZEPHYRUS-G14;Initial Catalog=codefdb;Persist Security Info=True;User ID=sa;Password=6vsPKz6PrX11qM;Trust Server Certificate=True"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            //Register your NewMain class so that IMediator can be injected
            services.AddTransient<MicrosoftImplementation>();
            //Build el ServiceProvider
            var provider = services.BuildServiceProvider();
            //Resolve NewMain from the provider
            var newMain = provider.GetRequiredService<MicrosoftImplementation>();
            await newMain.Apply();
            #endregion

            #region Memento
            Console.WriteLine();
            Console.WriteLine("Testing Memento Pattern");
            var textEditor = new EditorTexto();
            var historial = new Historial();

            textEditor.Write("Hello, David.");
            historial.Save(textEditor);

            textEditor.Write(" How are you doing?");
            historial.Save(textEditor);
            textEditor.Write(" I hope you are well.");
            Console.WriteLine(textEditor.Read());

            historial.Undo(textEditor);
            Console.WriteLine(textEditor.Read());

            historial.Undo(textEditor);
            Console.WriteLine(textEditor.Read());
            #endregion

            #region Observer
            Console.WriteLine();
            Console.WriteLine("Testing Observer Pattern");
            var sensor = new TemperatureSensor();
            var alertSystem = new TemperatureAlert();

            var subscription = sensor.Subscribe(alertSystem);
            //Subscribe() adds alertSystem to the observers list inside sensor.
            //alertSystem immediately receives the current temperature via OnNext().
            //It also gets a reference to an Unsubscriber object that allows it to detach later if needed(Dispose()).
            sensor.SetTemperature(25); // No alert
            sensor.SetTemperature(21); // No alert
            sensor.SetTemperature(25); // No alert
            sensor.SetTemperature(20); // No alert
            sensor.SetTemperature(35); // Alert!
            subscription.Dispose(); // Unsubscribe
            //alertSystem.OnCompleted(); // Notify completion
            #endregion
        }


    }
}
