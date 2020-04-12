using System.Collections.Generic;

namespace PlantIO.Entities.Naming
{
    /// <summary>
    ///  https://www.ishs.org/sites/default/files/static/ScriptaHorticulturae_18.pdf
    /// </summary>
    public interface ICultivarName
    {
        string LatinName { get; set; }

        string Subspecies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ICollection<CultivarNameGroup> Groups { get; set; }
    }
}