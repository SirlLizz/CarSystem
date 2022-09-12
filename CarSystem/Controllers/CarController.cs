using CarSystem.Models;
using CarSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarSystem.Controllers
{
    /// <summary>
    /// Сlass to operations with cars
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Getting all cars
        /// </summary>
        /// <returns>All Cars</returns>
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _repository.GetAllCars();
        }

        /// <summary>
        /// Getting car by model
        /// </summary>
        /// <param name="model">Car Model</param>
        /// <returns>Car</returns>
        [HttpGet("{model}")]
        public ActionResult<Car> Get(string model)
        {
            try
            {
                return _repository.GetCar(model);
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
        /// Adding car
        /// </summary>
        /// <param name="car">Added Car</param>
        /// <returns>Car Model</returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Car car)
        {
            try
            {
                return _repository.AddCar(car);
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
        /// Changing car by model
        /// </summary>
        /// <param name="model">Car Model</param>
        /// <param name="car">Changeable Car</param>
        /// <returns>Car Model</returns>
        [HttpPut("{model}")]
        public ActionResult<string> Put(string model, [FromBody] Car car)
        {
            try
            {
                return _repository.ReplaceCar(model, car);
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
        /// Deleting car by model
        /// </summary>
        /// <param name="name">Cr Model to delete</param>
        /// <returns>Car Model</returns>
        [HttpDelete("{model}")]
        public ActionResult<string> Delete(string model)
        {
            try
            {
                return _repository.DeleteCar(model);
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
        /// Deleting all cars
        /// </summary>
        [HttpDelete]
        public void DeleteAll()
        {
            _repository.DeleteAllCars();
        }
    }
}
