
namespace BehavioralPatterns.Visitor
{
    public class PerimeterCalculator: ShapeVisitor
    {
        private double totalPerimeter = 0;
        double radiusOfCircle = 5;
        double sideOfSquare = 4;
        double triangleSide1 = 3;
        double triangleSide2 = 4;
        double triangleSide3 = 5;
        double heightOfTriangle = 6;

        public void visit(Circle circle)
        {
            // Calculate perimeter of circle and update totalPerimeter
            var tempResult = (2 * Math.PI * radiusOfCircle);
            totalPerimeter += tempResult;
        }

        public void visit(Square square)
        {
            // Calculate perimeter of square and update totalPerimeter
            var tempResult = (4 * sideOfSquare);
            totalPerimeter += tempResult;
        }

        public void visit(Triangle triangle)
        {
            // Calculate perimeter of triangle and update totalPerimeter
            var tempResult = (triangleSide1 + triangleSide2 + triangleSide3);
            totalPerimeter += tempResult;
        }

        public double getTotalPerimeter()
        {
            return totalPerimeter;
        }
    }
}
