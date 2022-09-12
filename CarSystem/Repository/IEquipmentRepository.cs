using CarSystem.Models;
using System.Collections.Generic;

namespace CarSystem.Repository
{
    public interface IEquipmentRepository
    {
        public string AddEquipment(Equipment equipment);
        public string ReplaceEquipment(string name, Equipment newEquipment);
        public List<Equipment> GetAllEquipments();
        public Equipment GetEquipment(string name);
        public string DeleteEquipment(string name);
        public void DeleteAllEquipments();
    }
}
