using CarDealership.DataAccess.Models;
using System.Linq;

namespace CarDealership.DataAccess
{
    public interface ICarRepository
    {
        IQueryable<Car> GetAll();
        Car Get(int id);
        void Create(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}