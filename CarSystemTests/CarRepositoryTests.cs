using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace CarSystemTests
{
    public class CarRepositoryTests
    {
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        private Car CreateCar(string model)
        {
            return new Car() { Color = "red", Engine = "2JZ", Equipment = "Max", Model = model, Price = 800000 };
        }

        [Fact]
        public void AddCarTest()
        {
            string model = "Vesta";
            CarRepository carRepository = new(Config);
            carRepository.AddCar(CreateCar(model));
            Assert.Equal("2JZ", carRepository.GetCar(model).Engine);
            carRepository.DeleteCar(model);
        }

        [Fact]
        public void DeleteCarTest()
        {
            string model = "Kalina";
            CarRepository carRepository = new(Config);
            carRepository.AddCar(CreateCar(model));
            Assert.Equal(model, carRepository.DeleteCar(model));
        }

        [Fact]
        public void ReplaceCarTest()
        {
            string model = "Granta";
            CarRepository carRepository = new(Config);
            carRepository.AddCar(CreateCar(model));
            Assert.Equal(model, carRepository.ReplaceCar(model, CreateCar(model)));
            carRepository.DeleteCar(model);
        }
    }
}
