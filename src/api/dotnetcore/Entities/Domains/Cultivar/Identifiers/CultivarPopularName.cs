using System;

namespace PlantIO.Entities.Cultivar
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

        public CultivarPopularNameUsages Usage { get; set; }
    }

    [Flags]
    public enum CultivarPopularNameUsages : byte
    {
        Any = 0,
        Farming = 1,
        Conversation = 2,
        Comercial = 4,
    }
}