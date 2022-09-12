﻿namespace CarSystem.Models
{
    /// <summary>
    /// Car
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Car's model
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Car's color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Car's engine
        /// </summary>
        public Engine Engine { get; set; }
        /// <summary>
        /// Car's equipment
        /// </summary>
        public Equipment Equipment { get; set; }
        /// <summary>
        /// Car's price
        /// </summary>
        public double Price { get; set; }

    }
}
