using System;

namespace ProjectRaises
{
    class Program
    {
        const double percentageRaise = 1.04;

        static void Main(string[] args)
        {
            int employee1Salary;
            int employee2Salary;
            int employee3Salary;

            employee1Salary = 1000;
            employee2Salary = 1546;
            employee3Salary = 325;

            Console.WriteLine($"The next year employee 1 salary will be: {employee1Salary * percentageRaise}");
            Console.WriteLine($"The next year employee 2 salary will be: {employee2Salary * percentageRaise}");
            Console.WriteLine($"The next year employee 3 salary will be: {employee3Salary * percentageRaise}");
        }
    }
}