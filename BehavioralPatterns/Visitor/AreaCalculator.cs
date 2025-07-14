
namespace BehavioralPatterns.Visitor
{
    // Concrete Visitors
    public class AreaCalculator : ShapeVisitor
    {
        private double totalArea = 0;
        double radiusOfCircle = 5;
        double sideOfSquare = 4;
        double baseOfTriangle = 3;
        double heightOfTriangle = 6;

        public void visit(Circle circle)
        {
            // Calculate area of circle and update totalArea
            var tempResult = Math.PI * Math.Pow(radiusOfCircle, 2);
            totalArea += tempResult;
        }

        public void visit(Square square)
        {
            // Calculate area of square and update totalArea
            var tempResult = Math.Pow(sideOfSquare, 2);
            totalArea += tempResult;
        }

        public void visit(Triangle triangle)
        {
            // Calculate area of triangle and update totalArea
            var tempResult = (baseOfTriangle * heightOfTriangle) / 2;
            totalArea += tempResult;
        }

        public double getTotalArea()
        {
            return totalArea;
        }
    }

}
