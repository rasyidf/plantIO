using System;

namespace PlantIO.Entities.Taxonomy
{
    public class TaxonTypeDataSetLookup : ITaxonTypeReference, IMultiDataSetData
    {
        public Guid? DataSetId { get; set; }
        public int TypeId { get; set; }
        public TaxonType Type { get; set; }

        public Guid? TargetDataSetId { get; set; }
        public int TargetTaxonTypeId { get; set; }
        public TaxonType TargetTaxonType { get; set; }
    }
}