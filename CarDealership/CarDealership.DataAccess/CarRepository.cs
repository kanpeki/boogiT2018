using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using CarDealership.DataAccess.Models;

namespace CarDealership.DataAccess
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _cars;

        public CarRepository()
        {
            _cars = GetCars();
        }

        public IQueryable<Car> GetAll()
        {
            return _cars.AsQueryable();
        }

        public Car Get(int id)
        {
            return _cars.Find(c => c.Id == id);
        }

        public void Create(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var existingCar = Get(car.Id);
            var properties = car.GetType().GetProperties().Where(p => !p.Name.Equals("Id"));
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(car);
                var propertyType = property.PropertyType;
                var defaultValue = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
                if ((defaultValue != null && Activator.CreateInstance(propertyType, updatedValue) != defaultValue) || updatedValue != null)
                {
                    property.SetValue(existingCar, updatedValue);
                }
            }
        }

        public void Delete(Car car)
        {
            _cars.Remove(car);
        }

        private static List<Car> GetCars()
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Id = 0,
                    Manufacturer = "Volkswagen",
                    Model = "Touareg",
                    ProductionYear = 2004,
                    Mileage = 234000,
                    RCAExpirationDate = new DateTime(2018, 3, 4)
                },
                new Car
                {
                    Id = 1,
                    Manufacturer = "BMW",
                    Model = "335i",
                    ProductionYear = 2007,
                    Mileage = 150060,
                    RCAExpirationDate = new DateTime(2018, 6, 1)
                },
                new Car
                {
                    Id = 2,
                    Manufacturer = "Audi",
                    Model = "S4",
                    ProductionYear = 2009,
                    Mileage = 170570,
                    RCAExpirationDate = new DateTime(2018, 5, 23)
                }
            };
            return cars;
        }

    }
}
