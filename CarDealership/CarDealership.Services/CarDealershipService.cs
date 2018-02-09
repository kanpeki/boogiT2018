using System;
using System.Linq;
using CarDealership.Common;
using CarDealership.DataAccess;
using CarDealership.DataAccess.Models;

namespace CarDealership.Services
{
    public class CarDealershipService : ICarDealershipService
    {
        private readonly ICarRepository _carRepository;

        public CarDealershipService()
        {
            _carRepository = new CarRepository();
        }

        public void ListCars()
        {
            var availableCars = _carRepository.GetAll();
            if (!availableCars.Any())
            {
                Console.WriteLine("Car inventory is empty");
            }
            else
            {
                Console.WriteLine("Cars in the current inventory:");
                foreach (var car in availableCars)
                {
                    ListCarDetails(car);
                }
            }
        }

        public void AddCar()
        {
            GetManufacturer(out string manufacturer);
            GetModel(out string model);
            GetProductionYear(out int productionYear);
            GetMileage(out int mileage);
            GetRCAExpirationDate(out DateTime expirationDate);
            var newId = _carRepository.GetAll().Count();
            var newCar = new Car
            {
                Id = newId,
                Manufacturer = manufacturer,
                Model = model,
                ProductionYear = productionYear,
                Mileage = mileage,
                RCAExpirationDate = expirationDate
            };
            _carRepository.Create(newCar);
            Console.WriteLine("The following car was added:");
            ListCarDetails(newCar);
        }

        public void EditCar()
        {
            int input;
            int[] allowedInputs = { 1, 2, 3, 4, 5, 6 };
            var availableCars = _carRepository.GetAll();
            if (!availableCars.Any())
            {
                Console.WriteLine("No cars to update. Inventory is empty.");
                return;
            }
            Console.WriteLine("Enter the id of the car to update");
            GetCarId(availableCars.Count(), out int carId);
            var updatedCar = new Car { Id = carId };

            do
            {
                Console.WriteLine("Choose action: ");
                Console.WriteLine("- to update the manufacturer press 1");
                Console.WriteLine("- to update the model press 2");
                Console.WriteLine("- to update the production year press 3");
                Console.WriteLine("- to update the mileage press 4");
                Console.WriteLine("- to update the RCA expiration date press 5");
                Console.WriteLine("- to save changes press 6");

                InputReader.GetPositiveNumber(out input);
                while (Array.IndexOf(allowedInputs, input) == -1)
                {
                    Console.WriteLine("Wrong input. Please enter one of the available options");
                    InputReader.GetPositiveNumber(out input);
                }
                if (input.Equals(allowedInputs[0]))
                {
                    GetManufacturer(out string manufacturer);
                    updatedCar.Manufacturer = manufacturer;
                }
                else if (input.Equals(allowedInputs[1]))
                {
                    GetModel(out string model);
                    updatedCar.Model = model;
                }
                else if (input.Equals(allowedInputs[2]))
                {
                    GetProductionYear(out int productionYear);
                    updatedCar.ProductionYear = productionYear;
                }
                else if (input.Equals(allowedInputs[3]))
                {
                    GetMileage(out int mileage);
                    updatedCar.Mileage = mileage;
                }
                else if (input.Equals(allowedInputs[4]))
                {
                    GetRCAExpirationDate(out DateTime expirationDate);
                    updatedCar.RCAExpirationDate = expirationDate;
                }
            } while (!input.Equals(allowedInputs[5]));
            _carRepository.Update(updatedCar);
            Console.WriteLine($"The car with id {carId} was updated");
        }

        public void DeleteCar()
        {
            var availableCars = _carRepository.GetAll();
            if (!availableCars.Any())
            {
                Console.WriteLine("No cars to remove. Inventory is empty.");
                return;
            }
            Console.WriteLine("Enter the id of the car to remove");
            GetCarId(availableCars.Count(), out int carId);
            var carToDelete = availableCars.First(c => c.Id == carId);
            _carRepository.Delete(carToDelete);
            Console.WriteLine($"The car with id {carId} was removed");
        }

        #region Private
        private void ListCarDetails(Car car)
        {
            Console.WriteLine(
                $"Id: {car.Id}, Manufaturer: {car.Manufacturer}, Model: {car.Model}, " +
                $"Production year: {car.ProductionYear}, Mileage: {car.Mileage}, " +
                $"RCA expiration date: {car.RCAExpirationDate:yyyy/MM/dd}");
        }

        private void GetManufacturer(out string manufacturer)
        {
            Console.WriteLine("Enter the car manufacturer");
            manufacturer = Console.ReadLine();
        }

        private void GetModel(out string model)
        {
            Console.WriteLine("Enter the car model");
            model = Console.ReadLine();
        }

        private void GetProductionYear(out int productionYear)
        {
            Console.WriteLine("Enter the production year");
            InputReader.GetPositiveNumber(out productionYear);
        }

        private void GetMileage(out int mileage)
        {
            Console.WriteLine("Enter the mileage");
            InputReader.GetPositiveNumber(out mileage);
        }

        private void GetRCAExpirationDate(out DateTime expirationDate)
        {
            Console.WriteLine("Enter the RCA expiration date (yyyy/MM/dd)");
            InputReader.GetDate(out expirationDate);
        }

        private void GetCarId(int availableCarCount, out int carId)
        {
            var idsRange = Enumerable.Range(1, availableCarCount - 1).AsQueryable();
            bool ok;
            do
            {
                InputReader.GetPositiveNumber(out carId);
                ok = idsRange.Contains(carId);
                if (!ok)
                {
                    Console.WriteLine("Enter a valid car id");
                }
            } while (!ok);
        }
        #endregion

    }
}