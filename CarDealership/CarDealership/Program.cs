using CarDealership.Services;
using System;
using CarDealership.Common;

namespace CarDealership
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDealershipService carDealershipService = new CarDealershipService();
            int[] allowedInputs = { 1, 2, 3, 4, 5 };
            int input;

            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("CarDealer menu:");
                Console.WriteLine("- to list all the cars press 1");
                Console.WriteLine("- to add a car press 2");
                Console.WriteLine("- to edit a car press 3");
                Console.WriteLine("- to delete a car press 4");
                Console.WriteLine("- to exit press 5");

                InputReader.GetPositiveNumber(out input);
                while (Array.IndexOf(allowedInputs, input) == -1)
                {
                    Console.WriteLine("Wrong input. Please enter one of the available options");
                    InputReader.GetPositiveNumber(out input);
                }
                if (input.Equals(allowedInputs[0]))
                {
                    carDealershipService.ListCars();
                }
                else if (input.Equals(allowedInputs[1]))
                {
                    carDealershipService.AddCar();
                }
                else if (input.Equals(allowedInputs[2]))
                {
                    carDealershipService.EditCar();
                }
                else if (input.Equals(allowedInputs[3]))
                {
                    carDealershipService.DeleteCar();
                }

            } while (!input.Equals(allowedInputs[4]));
        }
    }
}
