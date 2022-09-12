using CarSystem.Models;
using System.Collections.Generic;

namespace CarSystem.Repository
{
    public interface IEngineRepository
    {
        public string AddEngine(Engine engine);
        public string ReplaceEngine(string name, Engine newEngine);
        public List<Engine> GetAllEngines();
        public Engine GetEngine(string name);
        public string DeleteEngine(string name);
        public void DeleteAllEngines();
    }
}
