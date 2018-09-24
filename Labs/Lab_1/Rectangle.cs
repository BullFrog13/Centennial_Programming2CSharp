using System;

namespace Lab_1
{
    public class Rectangle
    {
        private double width;
        private double height;

        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be equal or less than 0. Value: {value} is incorrect");
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be equal or less than 0. Value: {value} is incorrect");
                }

                height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}