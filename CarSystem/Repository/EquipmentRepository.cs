using CarSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarSystem.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private List<Equipment> _equipment;
        private readonly string _fileName;

        public EquipmentRepository()
        {
            ReadFromFileEquipments();
        }

        public EquipmentRepository(IConfiguration configuration)
        {
            _fileName = configuration.GetValue<string>("EquipmentsFile");
            ReadFromFileEquipments();
        }

        public void ReadFromFileEquipments()
        {
            if (!File.Exists(_fileName))
            {
                _equipment = new List<Equipment>();
                return;
            }
            XmlSerializer formatter = new(typeof(List<Equipment>));
            using FileStream fileStream = new(_fileName, FileMode.OpenOrCreate);
            _equipment = (List<Equipment>)formatter.Deserialize(fileStream);

        }

        public void WriteToFileEquipments()
        {
            XmlSerializer formatter = new(typeof(List<Equipment>));
            using FileStream fileStream = new(_fileName, FileMode.Create);
            formatter.Serialize(fileStream, _equipment);
        }

        public string AddEquipment(Equipment equipment)
        {
            if (_equipment.Any(e => e.Name == equipment.Name && 
            e.Material == equipment.Material && 
            e.Conditioner == equipment.Conditioner && 
            e.RDisc == equipment.RDisc))
            {
                throw new ArgumentException();
            }
            _equipment.Add(equipment);
            WriteToFileEquipments();
            return equipment.Name;
        }

        public string ReplaceEquipment(string name, Equipment newEquipment)
        {
            int equipmentIndex = _equipment.FindIndex(engine => engine.Name == name);

            if (equipmentIndex == -1)
            {
                throw new ArgumentException();
            }
            Equipment equipment = _equipment[equipmentIndex];
            equipment.Name = name;
            equipment.Material = newEquipment.Material; 
            equipment.Conditioner = newEquipment.Conditioner;
            equipment.RDisc = newEquipment.RDisc;
            WriteToFileEquipments();
            return name;
        }

        public List<Equipment> GetAllEquipments()
        {
            return _equipment;
        }

        public Equipment GetEquipment(string name)
        {
            Equipment equipment = _equipment.FirstOrDefault(e => e.Name == name);  

            if (equipment is null)
            {
                throw new ArgumentException();
            }
            return equipment;
        }

        public string DeleteEquipment(string name)
        {
            Equipment equipment = GetEquipment(name);

            if (equipment == null)
            {
                throw new ArgumentException();
            }
            _equipment.Remove(equipment);
            WriteToFileEquipments();
            return name;
        }

        public void DeleteAllEquipments()
        {
            _equipment.Clear();
            WriteToFileEquipments();
        }
    }
}
