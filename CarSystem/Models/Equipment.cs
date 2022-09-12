namespace CarSystem.Models
{
    /// <summary>
    /// Equipment
    /// </summary>
    [System.Serializable]
    public class Equipment
    {
        /// <summary>
        /// Equipment's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Equipment's interior material
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// Equipment's the presence of an air conditioner
        /// </summary>
        public bool Conditioner { get; set; }
        /// <summary>
        /// Equipment's disc radius
        /// </summary>
        public int RDisc { get; set; }
    }
}
