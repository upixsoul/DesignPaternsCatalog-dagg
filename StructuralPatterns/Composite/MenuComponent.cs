
namespace StructuralPatterns.Composite
{
    // Component: Abstract base class for menu items and menus
    public abstract class MenuComponent
    {
        protected string _name;

        public MenuComponent(string name)
        {
            _name = name;
        }

        public abstract decimal GetPrice(); // Common operation to get total price
        public abstract void Display(string indent = ""); // Display the menu hierarchy
    }

    // Leaf: Represents individual menu items
    public class MenuItem : MenuComponent
    {
        private decimal _price;

        public MenuItem(string name, decimal price) : base(name)
        {
            _price = price;
        }

        public override decimal GetPrice()
        {
            return _price;
        }

        public override void Display(string indent)
        {
            Console.WriteLine($"{indent}- {_name} (${_price:F2})");
        }
    }

    // Composite: Represents menus that can contain menu items or other menus
    public class Menu : MenuComponent
    {
        private List<MenuComponent> _components = new List<MenuComponent>();

        public Menu(string name) : base(name)
        {
        }

        public void Add(MenuComponent component)
        {
            _components.Add(component);
        }

        public void Remove(MenuComponent component)
        {
            _components.Remove(component);
        }

        public override decimal GetPrice()
        {
            decimal totalPrice = 0;
            foreach (var component in _components)
            {
                totalPrice += component.GetPrice();
            }
            return totalPrice;
        }

        public override void Display(string indent)
        {
            Console.WriteLine($"{indent}+ {_name} (Total: ${GetPrice():F2})");
            foreach (var component in _components)
            {
                component.Display(indent + "  ");
            }
        }
    }
}
