using System;

namespace PlantIO.Entities.Taxonomy
{
    // #review: int is a small key. There are standard taxon ids defined by scientific community
    // consider: public string InternationalTaxonId { get; set; }
    public class TaxonDataSetLookup : ITaxonReference, IMultiDataSetData
    {
        public Guid? DataSetId { get; set; }
        public int TaxonId { get; set; }
        public Taxon Taxon { get; set; }

        public Guid? TargetDataSetId { get; set; }
        public int TargetTaxonId { get; set; }
        public TaxonType TargetTaxon { get; set; }
    }
}