namespace PlantIO.Entities.Naming
{
    /// <summary>
    ///     
    
    /// </summary>
    public class CultivarNameGroup : ICNCP
    {
        string Name { get; set; }

        /// <summary>
        /// Determines the casing of "Group/group" substantive on name, uppercase for standard and lowercase for informal names.
        /// <see cref="https://en.wikipedia.org/wiki/Cultivar_group" />
        /// </summary>
        bool ICNCP.IsStandard { get; set; }
    }

    public interface ICNCP
    {
        public bool IsStandard { get; set; }
    }
}