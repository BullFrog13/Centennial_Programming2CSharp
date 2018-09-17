using System;

namespace AdmissionModularized
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Result: {CheckStudentAcceptance(2.49, 2.5)}");
        }

        private static string CheckStudentAcceptance(double studentAverageGrade, double admissionScore)
        {
            return studentAverageGrade >= admissionScore ? "Accept" : "Reject";
        }
    }
}