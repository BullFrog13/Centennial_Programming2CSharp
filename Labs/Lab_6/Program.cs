using System;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c0 = new Complex(-2, 3);
            Complex c1 = new Complex(-2, 3);
            Complex c2 = new Complex(1, -2);

            Complex c3 = c1 + c2;
            Console.WriteLine("{0} + {1} = {2}", c1.TellAboutSelf(), c2.TellAboutSelf(), c3.TellAboutSelf());
            Console.WriteLine("{0} - {1} = {2}", c1.TellAboutSelf(), c2.TellAboutSelf(), (c1 - c2).TellAboutSelf());
            Console.WriteLine("{0} in polar form is {1:f2}cis({2:f2})", c3.TellAboutSelf(), c3.Modulus, c3.Argument);
            Console.WriteLine("{0} {1} {2}", c0.TellAboutSelf(), (c0 == c1) ? "=" : "!=", c1.TellAboutSelf());
            Console.WriteLine("{0} {1} {2}", c0.TellAboutSelf(), (c0 == c2) ? "=" : "!=", c2.TellAboutSelf());
            Console.WriteLine("{0} * {1} = {2}", c1.TellAboutSelf(), c2.TellAboutSelf(), c3.TellAboutSelf());

            Console.ReadKey();
        }
    }
}