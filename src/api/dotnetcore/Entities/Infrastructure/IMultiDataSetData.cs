using System;

namespace PlantIO.Entities
{
    public interface IMultiDataSetData
    {
        /// <summary>
        /// Imported from external database
        /// </summary>
        Guid? DataSetId { get; set; }
    }
}