using System;

namespace CarDealership.DataAccess.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public DateTime RCAExpirationDate { get; set; }
    }
}
