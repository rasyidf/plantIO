using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public class SpeciesTaxonEntity : TaxonEntity
    {
        public string BinomialName { get; set; }

        public virtual ICollection<SpeciesTaxonGroupRelation> GroupingTaxonRelations { get; set; }

        // #todo: cladistic / inheritance
        // CladeTaxon CurrentSpecies {get;set;}
        // CladeTaxon Parent1 {get;set;}
        // CladeTaxon Parent2 {get;set;}

        public SpeciesTaxonEntity() { }
        public SpeciesTaxonEntity(string binomialName, TaxonType taxonType)
        {
            BinomialName = binomialName;
            Taxon = new Taxon(binomialName, taxonType);
        }
    }

    public class SpeciesTaxonGroupRelation : ITaxonomicAssociation<GroupingTaxon, Taxon>
    {
        public int MethodologyId { get; set; }
        // #review: this is can be accessed by 'GroupTaxon.Methodology', but was duplicated here for index
        public virtual TaxonomicMethodology Methodology { get; set; } 
                
        public int SpeciesId { get; set; }
        public virtual SpeciesTaxonEntity Species { get; set; }

        public int GroupingTaxonTypeId { get; set; }
        public TaxonType GroupingTaxonType { get; set; } // #review: duplicate for key

        public int GroupingTaxonId { get; set; }
        public virtual GroupingTaxon GroupingTaxon { get; set; }

        public bool IsActive { get; set; }

        public SpeciesTaxonGroupRelation() { }
        /// <summary>
        /// Primary key constructor
        /// </summary>
        public SpeciesTaxonGroupRelation(int speciesId, int groupingTaxonId, int methodologyId)
        {
            SpeciesId = speciesId;
            GroupingTaxonId = groupingTaxonId;
            MethodologyId = methodologyId;
        }
        public SpeciesTaxonGroupRelation(SpeciesTaxonEntity species, GroupingTaxon groupingTaxon)
        {
            Methodology = groupingTaxon.Methodology;
            Species = species;
            GroupingTaxonType = groupingTaxon.TaxonType;
            GroupingTaxon = groupingTaxon;
        }
    }
}