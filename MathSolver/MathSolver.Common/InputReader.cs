using System;

namespace MathSolver.Common
{
    public static class InputReader
    {
        public static void GetPositiveNumber(out int number)
        {
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Please enter a positive number");
            }
        }
    }
}
