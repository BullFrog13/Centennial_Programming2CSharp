using System;

namespace Lab_4
{
    class Program
    {
        static void Main()
        {
            var date = new Date(2018, 9, 28);
            Console.WriteLine(date.TellAboutYourself());
            date.AddDays(5);
            Console.WriteLine(date.TellAboutYourself());

            var date1 = new Date(2018, 12, 30);
            Console.WriteLine(date1.TellAboutYourself());
            date1.AddDays(30);
            Console.WriteLine(date1.TellAboutYourself());
        }
    }
}