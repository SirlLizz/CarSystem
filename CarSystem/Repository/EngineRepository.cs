using CarSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarSystem.Repository
{
    public class EngineRepository : IEngineRepository
    {
        private List<Engine> _engines;
        private readonly string _fileName;

        public EngineRepository()
        {
            ReadFromFileEngines();
        }

        public EngineRepository(IConfiguration configuration)
        {
            _fileName = configuration.GetValue<string>("EnginesFile");
            ReadFromFileEngines();
        }

        public void ReadFromFileEngines()
        {
            if (!File.Exists(_fileName))
            {
                _engines = new List<Engine>();
                return;
            }
            XmlSerializer formatter = new(typeof(List<Engine>));
            using FileStream fileStream = new(_fileName, FileMode.OpenOrCreate);
            _engines = (List<Engine>)formatter.Deserialize(fileStream);

        }

        public void WriteToFileEngines()
        {
            XmlSerializer formatter = new(typeof(List<Engine>));
            using FileStream fileStream = new(_fileName, FileMode.Create);
            formatter.Serialize(fileStream, _engines);
        }

        public string AddEngine(Engine engine)
        {
            if (_engines.Any(e => e.Name == engine.Name && e.Size == engine.Size && e.Power == engine.Power))
            {
                throw new ArgumentException();
            }
            _engines.Add(engine);
            WriteToFileEngines();
            return engine.Name;
        }

        public string ReplaceEngine(string name, Engine newEngine)
        {
            int engineIndex = _engines.FindIndex(engine => engine.Name == name);

            if (engineIndex == -1)
            {
                throw new ArgumentException();
            }
            
            Engine engine = _engines[engineIndex];
            engine.Name = name;
            engine.Size = newEngine.Size;
            engine.Power = newEngine.Power;
            WriteToFileEngines();
            return name;
        }

        public List<Engine> GetAllEngines()
        {
            return _engines;
        }

        public Engine GetEngine(string name)
        {
            Engine engine = _engines.FirstOrDefault(e => e.Name == name);  

            if (engine is null)
            {
                throw new ArgumentException();
            }
            return engine;
        }

        public string DeleteEngine(string name)
        {
            Engine engine = GetEngine(name);

            if (engine == null)
            {
                throw new ArgumentException();
            }
            _engines.Remove(engine);
            WriteToFileEngines();
            return name;
        }

        public void DeleteAllEngines()
        {
            _engines.Clear();
            WriteToFileEngines();
        }
    }
}
