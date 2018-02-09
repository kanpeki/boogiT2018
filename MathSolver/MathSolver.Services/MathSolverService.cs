using MathSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathSolver.Services
{
    public class MathSolverService : IMathSolverService
    {
        public void CalculateClosestHigherPrime()
        {
            Console.WriteLine("Enter the number for which you want to find the closest higher prime");
            InputReader.GetPositiveNumber(out int number);
            var result = GetPrime(number);
            Console.WriteLine($"The closest higher prime is: {result}\n");
        }

        public void CalculateGreatestCommonDivisor()
        {
            ReadDivisorCheckData(out int firstNumber, out int secondNumber);
            var result = GetGCD(firstNumber, secondNumber);
            Console.WriteLine($"The greatest common divisor is: {result}\n");
        }

        public void ListElementsStartingWithPattern()
        {
            ReadPatternMatchingData(out List<string> userList, out string pattern);
            var matchingElements = userList.Where(e => e.StartsWith(pattern)).AsQueryable();
            PrintResult(pattern, "starting", matchingElements);
        }

        public void ListElementsEndingWithPattern()
        {
            ReadPatternMatchingData(out List<string> userList, out string pattern);
            var matchingElements = userList.Where(e => e.EndsWith(pattern)).AsQueryable();
            PrintResult(pattern, "ending", matchingElements);
        }

        public void CheckIfCoPrimes()
        {
            ReadDivisorCheckData(out int firstNumber, out int secondNumber);
            var result = GetGCD(firstNumber, secondNumber);
            Console.WriteLine(result == 1 ? "The numbers are co-primes" : "The numbers are not co-primes");
        }

        #region Private
        private int GetPrime(int number)
        {
            var result = number + 1;
            while (!IsPrime(result))
            {
                result++;
            }
            return result;
        }

        private bool IsPrime(int number)
        {
            if (number == 2 || number == 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;
            int step = 2;
            for (int i = 5; i * i <= number; i += step)
            {
                if (number % i == 0)
                    return false;
                step = 6 - step;
            }
            return true;
        }

        private void ReadDivisorCheckData(out int firstNumber, out int secondNumber)
        {
            Console.WriteLine("Enter the first number");
            InputReader.GetPositiveNumber(out firstNumber);
            Console.WriteLine("Enter the second number");
            InputReader.GetPositiveNumber(out secondNumber);
        }

        private int GetGCD(int firstNumber, int secondNumber)
        {
            if (secondNumber > 0)
                return GetGCD(secondNumber, firstNumber % secondNumber);
            return firstNumber;
        }

        private void ReadPatternMatchingData(out List<string> userList, out string pattern)
        {
            Console.WriteLine("Enter array size");
            InputReader.GetPositiveNumber(out int size);

            userList = new List<string>();
            Console.WriteLine("Enter array members ");
            for (int i = 0; i < size; i++)
            {
                userList.Add(Console.ReadLine());
            }

            Console.WriteLine("Enter the pattern to be matched");
            pattern = Console.ReadLine();
        }

        private void PrintResult(string pattern, string position, IQueryable<string> matchingElements)
        {
            if (!matchingElements.Any())
            {
                Console.WriteLine($"No elements {position} with `{pattern}` were found\n");
            }
            else
            {
                Console.WriteLine($"Elements {position} with `{pattern}`: {string.Join(", ", matchingElements)}");
            }
        }
        #endregion
    }
}
