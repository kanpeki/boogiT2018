using System;
using System.Globalization;

namespace CarDealership.Common
{
    public class InputReader
    {
        public static void GetPositiveNumber(out int number)
        {
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Please enter a positive number");
            }
        }

        public static void GetDate(out DateTime date)
        {
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date))
            {
                Console.WriteLine("Please enter the date in the specified format (yyyy/MM/dd)");
            }
        }
    }
}
