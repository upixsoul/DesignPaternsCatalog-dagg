
namespace BehavioralPatterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver: The object that performs the actual work
    public class TextEditor
    {
        private string _text = string.Empty;

        public void AddText(string text)
        {
            _text += text;
            Console.WriteLine($"Current text: {_text}");
        }

        public void RemoveText(string text)
        {
            int length = text.Length;
            if (_text.Length >= length)
            {
                _text = _text.Substring(0, _text.Length - length);
                Console.WriteLine($"Current text after undo: {_text}");
            }
        }
    }

    // Concrete Command: Encapsulates the "type text" operation
    public class TypeTextCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly string _text;

        public TypeTextCommand(TextEditor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.AddText(_text);
        }

        public void Undo()
        {
            _editor.RemoveText(_text);
        }
    }

    // Invoker: Manages the execution and undo of commands
    public class TextEditorInvoker
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command); // Store for undo
        }

        public void UndoCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand command = _commandHistory.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }
    }
}
