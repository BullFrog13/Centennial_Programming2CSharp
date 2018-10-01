namespace Lab_1
{
    public class Rectangle
    {
        private double width;
        private double height;

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    width = 1;
                }

                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    height = 1;
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