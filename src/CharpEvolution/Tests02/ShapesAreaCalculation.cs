using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests02
{
    public class ShapesAreaCalculation : IShapesAreaCalculation
    {
        private readonly ICalculatorValidation _calculatorValidation;

        public ShapesAreaCalculation(ICalculatorValidation calculatorValidation)
        {
            _calculatorValidation = calculatorValidation;
        }

        public void GetTriangleArea()
        {
            var height = _calculatorValidation.SetNumber("Please enter the height of the triangle: ");
            var baseOfTriangle = _calculatorValidation.SetNumber("Please enter the base of the triangle: ");
            var area = (height * baseOfTriangle) / 2;

            Console.WriteLine("The Triangle area is " + area);
        }

        public void GetRectangleArea()
        {
            var length = _calculatorValidation.SetNumber("Please enter the length of the rectangle: ");
            var width = _calculatorValidation.SetNumber("Please enter the width of the rectangle: ");
            var area = length * width;

            Console.WriteLine("The Rectangle area is " + area);
        }

        public void GetCircleArea()
        {
            var radius = _calculatorValidation.SetNumber("Please enter the radius of the circle: ");
            var area = 3.14159 * radius * radius;

            Console.WriteLine("The Circle area is " + area);
        }

        public void GetSquareArea()
        {
            var side = _calculatorValidation.SetNumber("Please enter the side of the square: ");
            var area = side * side;

            Console.WriteLine("The Square area is " + area);
        }
    }
}
