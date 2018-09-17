using System;

namespace OddNums
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i = 1; i < 100; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}