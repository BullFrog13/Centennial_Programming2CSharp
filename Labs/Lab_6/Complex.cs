using System;
using System.Runtime.Remoting.Proxies;
using System.Text;

namespace Lab_6
{
    public class Complex
    {
        private double argument;
        private int imaginary;
        private double modulus;
        private int real;

        public double Argument
        {
            get
            {
                return 1 / Math.Atan(Real / Imaginary);
            }
        }

        public int Imaginary { get; private set; }

        public double Modulus
        {
            get
            {
                return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
            }
        }

        public int Real { get; private set; }

        public Complex(int real = 0, int imaginary = 0)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            int real = lhs.Real + rhs.Real;
            int imaginary = lhs.Imaginary + rhs.Imaginary;

            return new Complex(real, imaginary);
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            int real = lhs.Real - rhs.Real;
            int imaginary = lhs.Imaginary - rhs.Imaginary;

            return new Complex(real, imaginary);
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary;
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return lhs.Real != rhs.Real && lhs.Imaginary != rhs.Imaginary;
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            int real = lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary;
            int imaginary = lhs.Real * rhs.Imaginary + lhs.Imaginary * rhs.Real;

            return new Complex(real, imaginary);
        }

        public string TellAboutSelf()
        {
            var stringBuilder = new StringBuilder(150);
            stringBuilder.Append($"Argument: {Argument}\n");
            stringBuilder.Append($"Imaginary: {Imaginary}\n");
            stringBuilder.Append($"Modulus: {Modulus}\n");
            stringBuilder.Append($"Real: {Real}\n");

            return stringBuilder.ToString();
        }
    }
}