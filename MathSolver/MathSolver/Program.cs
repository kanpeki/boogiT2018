using MathSolver.Common;
using MathSolver.Services;
using System;

namespace MathSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IMathSolverService mathSolverService = new MathSolverService();
            int[] allowedInputs = { 1, 2, 3, 4, 5, 6 };
            int input;

            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("MathSolver menu:");
                Console.WriteLine("- to calculate the higher prime closest to a given number press 1");
                Console.WriteLine("- to calculate the Greatest Common Divisor of two numbers press 2");
                Console.WriteLine("- to display all the elements of an array starting with a given sequence press 3");
                Console.WriteLine("- to display all the elements of an array ending with a given sequence press 4");
                Console.WriteLine("- to check if two numbers are co-primes press 5");
                Console.WriteLine("- to exit press 6");

                InputReader.GetPositiveNumber(out input);
                while (Array.IndexOf(allowedInputs, input) == -1)
                {
                    Console.WriteLine("Wrong input. Please enter one of the available options");
                    InputReader.GetPositiveNumber(out input);
                }
                if (input.Equals(allowedInputs[0]))
                {
                    mathSolverService.CalculateClosestHigherPrime();
                }
                else if (input.Equals(allowedInputs[1]))
                {
                    mathSolverService.CalculateGreatestCommonDivisor();
                }
                else if (input.Equals(allowedInputs[2]))
                {
                    mathSolverService.ListElementsStartingWithPattern();
                }
                else if (input.Equals(allowedInputs[3]))
                {
                    mathSolverService.ListElementsEndingWithPattern();
                }
                else if (input.Equals(allowedInputs[4]))
                {
                    mathSolverService.CheckIfCoPrimes();
                }
            } while (!input.Equals(allowedInputs[5]));
        }
    }
}
