
namespace BehavioralPatterns.Memento
{
    //Memento
    public class MementoText
    {
        public string State { get; }

        public MementoText(string state)
        {
            State = state;
        }
    }

    //Originator
    public class EditorTexto
    {
        private string content;

        public void Write(string text)
        {
            content += text;
        }

        public string Read()
        {
            return content;
        }

        public MementoText CreateMemento()
        {
            return new MementoText(content);
        }

        public void Restore(MementoText mementoText)
        {
            content = mementoText.State;
        }
    }

    //Caretaker
    public class Historial
    {
        private readonly Stack<MementoText> history = new();

        public void Save(EditorTexto editor)
        {
            history.Push(editor.CreateMemento());
        }

        public void Undo(EditorTexto editor)
        {
            if (history.Count > 0)
            {
                var memento = history.Pop();
                editor.Restore(memento);
            }
        }
    }

}
