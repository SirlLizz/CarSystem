using CarSystemClient.Properties;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarSystemClient
{
    public class CarSystemRepository
    {
        private readonly CarSystemAPIClient _openApiClient;
        public CarSystemRepository()
        {
            var httpClient = new HttpClient();
            var baseUrl = Settings.Default.CarSystemClient;
            _openApiClient = new CarSystemAPIClient(baseUrl, httpClient);
        }
        public Task<ICollection<Engine>> GetAllEngines()
        {
            return _openApiClient.EngineAllAsync();
        }
        public Task<string> AddEngine(Engine engine)
        {
            return _openApiClient.EngineAsync(engine);
        }
        public Task DeleteAllEngines()
        {
            return _openApiClient.Engine2Async();
        }
        public Task<Engine> GetEngine(string model)
        {
            return _openApiClient.Engine3Async(model);
        }
        public Task<string> ReplaceEngine(string model, Engine newEngine)
        {
            return _openApiClient.Engine4Async(model, newEngine);
        }
        public Task<string> DeleteEngine(string model)
        {
            return _openApiClient.Engine5Async(model);
        }
        public Task<ICollection<Car>> GetAllCars()
        {
            return _openApiClient.CarAllAsync();
        }
        public Task<string> AddCar(Car car)
        {
            return _openApiClient.CarAsync(car);
        }
        public Task DeleteAllCars()
        {
            return _openApiClient.Car2Async();
        }
        public Task<Car> GetCar(string name)
        {
            return _openApiClient.Car3Async(name);
        }
        public Task<string> ReplaceCar(string name, Car newCar)
        {
            return _openApiClient.Car4Async(name, newCar);
        }
        public Task<string> DeleteCar(string name)
        {
            return _openApiClient.Car5Async(name);
        }
        public Task<ICollection<Equipment>> GetAllEquipments()
        {
            return _openApiClient.EquipmentAllAsync();
        }
        public Task<string> AddEquipment(Equipment equipment)
        {
            return _openApiClient.EquipmentAsync(equipment);
        }
        public Task DeleteAllEquipments()
        {
            return _openApiClient.Equipment2Async();
        }
        public Task<Equipment> GetEquipment(string name)
        {
            return _openApiClient.Equipment3Async(name);
        }
        public Task<string> ReplaceEquipment(string name, Equipment newEquipment)
        {
            return _openApiClient.Equipment4Async(name, newEquipment);
        }
        public Task<string> DeleteEquipment(string name)
        {
            return _openApiClient.Equipment5Async(name);
        }
    }
}
