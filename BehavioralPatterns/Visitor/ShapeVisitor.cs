
namespace BehavioralPatterns.Visitor
{
    // Visitor interface
    public interface ShapeVisitor
    {
        void visit(Circle circle);
        void visit(Square square);
        void visit(Triangle triangle);
    }

    // Element interface
    public interface Shape
    {
        void accept(ShapeVisitor visitor);
    }

    // Concrete Elements
    public class Circle: Shape
    {
        public void accept(ShapeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Square: Shape
    {
        public void accept(ShapeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Triangle : Shape
    {
        public void accept(ShapeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
