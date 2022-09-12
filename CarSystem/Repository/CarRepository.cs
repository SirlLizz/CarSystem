using CarSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarSystem.Repository
{
    public class CarRepository : ICarRepository
    {
        private List<Car> _cars;
        private readonly string _fileName;

        public CarRepository()
        {
            ReadFromFileCars();
        }

        public CarRepository(IConfiguration configuration)
        {
            _fileName = configuration.GetValue<string>("CarsFile");
            ReadFromFileCars();
        }

        public void ReadFromFileCars()
        {
            if (!File.Exists(_fileName))
            {
                _cars = new List<Car>();
                return;
            }
            XmlSerializer formatter = new(typeof(List<Car>));
            using FileStream fileStream = new(_fileName, FileMode.OpenOrCreate);
            _cars = (List<Car>)formatter.Deserialize(fileStream);

        }

        public void WriteToFileCars()
        {
            XmlSerializer formatter = new(typeof(List<Car>));
            using FileStream fileStream = new(_fileName, FileMode.Create);
            formatter.Serialize(fileStream, _cars);
        }

        public string AddCar(Car car)
        {
            if (_cars.Any(c => c.Model == car.Model && 
            c.Color == car.Color && 
            c.Engine == car.Engine && 
            c.Equipment == car.Equipment && 
            c.Price == car.Price) || car.Engine == null || car.Equipment == null)
            {
                throw new ArgumentException();
            }
            _cars.Add(car);
            WriteToFileCars();
            return car.Model;
        }

        public string ReplaceCar(string model, Car newCar)
        {
            int carIndex = _cars.FindIndex(engine => engine.Model == model);

            if (carIndex == -1)
            {
                throw new ArgumentException();
            }
            Car car = _cars[carIndex];
            car.Model = model;
            car.Color = newCar.Color;
            car.Engine = newCar.Engine;
            car.Equipment = newCar.Equipment;
            car.Price = newCar.Price;
            WriteToFileCars();
            return model;
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public Car GetCar(string model)
        {
            Car car = _cars.FirstOrDefault(e => e.Model == model);  

            if (car is null)
            {
                throw new ArgumentException();
            }
            return car;
        }

        public string DeleteCar(string model)
        {
            Car car = GetCar(model);

            if (car == null)
            {
                throw new ArgumentException();
            }
            _cars.Remove(car);
            WriteToFileCars();
            return model;
        }

        public void DeleteAllCars()
        {
            _cars.Clear();
            WriteToFileCars();
        }
    }
}
