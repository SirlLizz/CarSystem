using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarSystem.Controllers
{
    /// <summary>
    /// Сlass to operations with engines
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineRepository _repository;

        public EngineController(IEngineRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Getting all engines
        /// </summary>
        /// <returns>All Engines</returns>
        [HttpGet]
        public IEnumerable<Engine> GetAll()
        {
            return _repository.GetAllEngines();
        }

        /// <summary>
        /// Getting engine by name
        /// </summary>
        /// <param name="name">Engine Name</param>
        /// <returns>Engine</returns>
        [HttpGet("{name}")]
        public ActionResult<Engine> Get(string name)
        {
            try
            {
                return _repository.GetEngine(name);
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
        /// Adding engine
        /// </summary>
        /// <param name="engine">Added Engine</param>
        /// <returns>Engine Name</returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Engine engine)
        {
            try
            {
                return _repository.AddEngine(engine);
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
        /// Changing engine by name
        /// </summary>
        /// <param name="name">Engine Name</param>
        /// <param name="engine">Changeable Engine</param>
        /// <returns>Engine Name</returns>
        [HttpPut("{name}")]
        public ActionResult<string> Put(string name, [FromBody] Engine engine)
        {
            try
            {
                return _repository.ReplaceEngine(name, engine);
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
        /// Deleting engine by name
        /// </summary>
        /// <param name="name">Engine Name to delete</param>
        /// <returns>Engine Name</returns>
        [HttpDelete("{name}")]
        public ActionResult<string> Delete(string name)
        {
            try
            {
                return _repository.DeleteEngine(name);
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
        /// Deleting all engines
        /// </summary>
        [HttpDelete]
        public void DeleteAll()
        {
            _repository.DeleteAllEngines();
        }
    }
}
