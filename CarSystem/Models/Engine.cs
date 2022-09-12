namespace CarSystem.Models
{
    /// <summary>
    /// Engine
    /// </summary>
    [System.Serializable]
    public class Engine
    {
        /// <summary>
        /// Engine's model
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Engine's size
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// Engine's power
        /// </summary>
        public double Power { get; set; }
    }
}
