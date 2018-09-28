using System;

namespace Lab_3
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

            var date2 = new Date(2018, 6, 15);
            Console.WriteLine(date2.TellAboutYourself());
            date2.AddDays(300);
            Console.WriteLine(date2.TellAboutYourself());

            var date3 = new Date(2018, 1, 5);
            Console.WriteLine(date3.TellAboutYourself());
            date3.AddDays(386);
            Console.WriteLine(date3.TellAboutYourself());
        }
    }
}