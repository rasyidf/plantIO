using System;

namespace PlantIO.Entities
{
    public class CultivarPopularName : IMultiDataSetRegionalData
    {
        public Guid? DataSetId { get; set; }
        public Guid? RegionId { get; set; }

        public Guid CultivarId { get; set; }

        /// <summary>
        /// pt-BR; pt-BR-hue; pt-BR-MG; pt-BR-SP-Sampa;
        /// </summary>
        public string LanguageCultureName { get; set; }

        public string Name { get; set; }
    }
}