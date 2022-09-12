using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace CarSystemTests
{
    public class EngineRepositoryTests
    {
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        private Engine CreateEngine(string name)
        {
            return new Engine() { Name = name, Power = 100, Size = 1.6 };
        }

        [Fact]
        public void AddEngineTest()
        {
            string name = "JZ";
            EngineRepository engineRepository = new(Config);
            Assert.Equal(name, engineRepository.AddEngine(CreateEngine(name)));
            engineRepository.DeleteEngine(name);
        }

        [Fact]
        public void DeleteEngineTest()
        {
            string name = "2JZ";
            EngineRepository engineRepository = new(Config);
            engineRepository.AddEngine(CreateEngine(name));
            Assert.Equal(name, engineRepository.DeleteEngine(name));
        }

        [Fact]
        public void ReplaceEngineTest()
        {
            string name = "2UZ";
            EngineRepository engineRepository = new(Config);
            engineRepository.AddEngine(CreateEngine(name));
            Assert.Equal(name, engineRepository.ReplaceEngine(name, CreateEngine(name)));
            engineRepository.DeleteEngine(name);
        }
    }
}
