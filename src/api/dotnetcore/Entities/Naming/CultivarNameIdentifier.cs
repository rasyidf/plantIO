using System;
using System.Collections.Generic;
using PlantIO.Entities.Naming;

namespace PlantIO.Entities
{
    /// <summary>
    /// Correlates botanical and standard cultivar names with a GUID in a specified DataSet
    /// </summary>
    public partial class CultivarNameIdentifier : ICultivarName, IMultiDataSetData
    {
        public Guid? DataSetId { get; set; }

        /// <summary>
        /// The GUID for cultivar name in the specified database
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string LatinName { get; set; }
        public string Subspecies { get; set; }
        public string Taxa { get; set; }

        public ICollection<CultivarNameGroup> Groups { get; set; }
    }

#if IPNI
    public partial class CultivarNameIdentifier 
    {
        /// <summary>
        /// Life Sciences Identifier
        /// </summary>
        public string LSID { get; set; }
    }
#endif
}
