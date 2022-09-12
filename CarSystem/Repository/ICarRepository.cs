using CarSystem.Models;
using System.Collections.Generic;

namespace CarSystem.Repository
{
    public interface ICarRepository
    {
        public string AddCar(Car car);
        public string ReplaceCar(string model, Car newCar);
        public List<Car> GetAllCars();
        public Car GetCar(string model);
        public string DeleteCar(string model);
        public void DeleteAllCars();
    }
}
