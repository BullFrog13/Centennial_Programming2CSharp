using System;

namespace Lab_1
{
    class Program
    {
        static void Main()
        {
            var smallRectangle = CreateRectangle(4, 5);
            DescribeRectangle(smallRectangle);
            CalculateAndDisplayArea(smallRectangle);
        }

        static void DescribeRectangle(Rectangle rectangle)
        {
            Console.WriteLine($"Rectangle width: {rectangle.Width}");
            Console.WriteLine($"Rectangle height: {rectangle.Height}");
        }

        static void CalculateAndDisplayArea(Rectangle rectangle)
        {
            Console.WriteLine($"Rectangle area: {rectangle.Width * rectangle.Height}");
        }

        static Rectangle CreateRectangle(double width, double height)
        {
            return new Rectangle(width, height);
        }
    }
}