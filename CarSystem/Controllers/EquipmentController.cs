using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarSystem.Controllers
{
    /// <summary>
    /// Сlass to operations with Equipments
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentController(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Getting all Equipments
        /// </summary>
        /// <returns>All Equipments</returns>
        [HttpGet]
        public IEnumerable<Equipment> GetAll()
        {
            return _repository.GetAllEquipments();
        }

        /// <summary>
        /// Getting Equipment by name
        /// </summary>
        /// <param name="name">Equipment Name</param>
        /// <returns>Equipment</returns>
        [HttpGet("{name}")]
        public ActionResult<Equipment> Get(string name)
        {
            try
            {
                return _repository.GetEquipment(name);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }

        }

        /// <summary>
        /// Adding Equipment
        /// </summary>
        /// <param name="engine">Added Equipment</param>
        /// <returns>Equipment Name</returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Equipment equipment)
        {
            try
            {
                return _repository.AddEquipment(equipment);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Changing Equipment by name
        /// </summary>
        /// <param name="name">Equipment Name</param>
        /// <param name="equipment">Changeable Equipment</param>
        /// <returns>Equipment Name</returns>
        [HttpPut("{name}")]
        public ActionResult<string> Put(string name, [FromBody] Equipment equipment)
        {
            try
            {
                return _repository.ReplaceEquipment(name, equipment);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Deleting Equipment by name
        /// </summary>
        /// <param name="name">Equipment Name to delete</param>
        /// <returns>Equipment Name</returns>
        [HttpDelete("{name}")]
        public ActionResult<string> Delete(string name)
        {
            try
            {
                return _repository.DeleteEquipment(name);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Deleting all Equipments
        /// </summary>
        [HttpDelete]
        public void DeleteAll()
        {
            _repository.DeleteAllEquipments();
        }
    }
}
