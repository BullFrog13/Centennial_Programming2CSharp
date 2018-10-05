using System;
using System.Globalization;

namespace Lab_4
{
    class Program
    {
        static void Main()
        {
            var date = new Date(2018, 9, 28);
            Console.Write(date.TellAboutYourself());
            date.AddDays(5);
            Console.Write("---");
            Console.WriteLine(date.TellAboutYourself());
            Console.WriteLine();

            var date1 = new Date(2018, 12, 30);
            Console.Write(date1.TellAboutYourself());
            date1.AddDays(30);
            Console.Write("---");
            Console.WriteLine(date1.TellAboutYourself());
            Console.WriteLine();

            var date2 = new Date(2018, 6, 15);
            Console.Write(date2.TellAboutYourself());
            date2.AddDays(300);
            Console.Write("---");
            Console.WriteLine(date2.TellAboutYourself());
            Console.WriteLine();

            var date3 = new Date(2018, 1, 5);
            Console.Write(date3.TellAboutYourself());
            date3.AddDays(386);
            Console.Write("---");
            Console.WriteLine(date3.TellAboutYourself());
        }
    }
}