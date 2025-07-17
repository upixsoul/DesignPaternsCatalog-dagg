
namespace StructuralPatterns.Composite
{
    // Component: The abstract base class or interface
    public abstract class FileSystemComponent
    {
        protected string _name;

        public FileSystemComponent(string name)
        {
            _name = name;
        }

        public abstract int GetSize(); // Common operation for both leaf and composite
        public abstract void Display(string indent = "");
    }

    // Leaf: Represents individual files
    public class File : FileSystemComponent
    {
        private int _size;

        public File(string name, int size) : base(name)
        {
            _size = size;
        }

        public override int GetSize()
        {
            return _size;
        }

        public override void Display(string indent)
        {
            Console.WriteLine($"{indent}- File: {_name} ({_size} KB)");
        }
    }

    // Composite: Represents directories that can contain files or other directories
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _components = new List<FileSystemComponent>();

        public Directory(string name) : base(name)
        {
        }

        public void Add(FileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _components.Remove(component);
        }

        public override int GetSize()
        {
            int totalSize = 0;
            foreach (var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }

        public override void Display(string indent)
        {
            Console.WriteLine($"{indent}+ Directory: {_name} ({GetSize()} KB)");
            foreach (var component in _components)
            {
                component.Display(indent + "  ");
            }
        }
    }
}
