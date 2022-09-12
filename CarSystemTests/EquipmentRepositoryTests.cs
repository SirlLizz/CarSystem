using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace CarSystemTests
{
    public class EquipmentRepositoryTests
    {
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        private Equipment CreateEquipment(string name)
        {
            return new Equipment() { Name = name, Conditioner = true, Material = "velur", RDisc = 18 };
        }

        [Fact]
        public void AddEquipmentTest()
        {
            string name = "LZ";
            EquipmentRepository equipmentRepository = new(Config);
            Assert.Equal(name, equipmentRepository.AddEquipment(CreateEquipment(name)));
            equipmentRepository.DeleteEquipment(name);
        }

        [Fact]
        public void DeleteEquipmentTest()
        {
            string name = "RLZ";
            EquipmentRepository equipmentRepository = new(Config);
            equipmentRepository.AddEquipment(CreateEquipment(name));
            Assert.Equal(name, equipmentRepository.DeleteEquipment(name));
        }

        [Fact]
        public void ReplaceEquipmentTest()
        {
            string name = "TLZ";
            EquipmentRepository equipmentRepository = new(Config);
            equipmentRepository.AddEquipment(CreateEquipment(name));
            Assert.Equal(name, equipmentRepository.ReplaceEquipment(name, CreateEquipment(name)));
            equipmentRepository.DeleteEquipment(name);
        }
    }
}
