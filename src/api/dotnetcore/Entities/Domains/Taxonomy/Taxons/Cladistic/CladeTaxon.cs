using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    [Obsolete("prototype")]
    public class CladeTaxon : TaxonEntity, ITaxonReference
    {
        // public int TaxonId { get; set; }
        // public Taxon Taxon { get; set; }
    }

    #region // #todo: clade modeling
    // Node-based: "the clade originating with the most recent common ancestor of A and B" or "the least inclusive clade containing A and B"
    // Branch-based: "the clade consisting of A and all organisms or species that share a more recent common ancestor with A than with Z" or "the most inclusive clade containing A but not Z." Another term for definitions of this sort is stem-based.
    // Apomorphy-based: "the clade originating with the first organism or species to possess apomorphy M inherited by A".

    // #review: is it possible to use SQL hierarchy / Recursive CTEs to retrieve entire lineage & grade ranks in a performant way (SQLServer/SQLite/MySQL/Postgree)?

    [Obsolete("prototype")]
    public class CladeTaxonWithSelfReference : ITaxonReference
    {
        public Guid? ParentId { get; set; }
        public CladeTaxonWithSelfReference Parent { get; set; }

        public int TaxonId { get; set; }
        public Taxon Taxon { get; set; }
    }

    [Obsolete("prototype")]
    public class CladeTaxonNodeRelation // : ITaxonValue<CladeTaxon>
    {
        public Guid TargetTaxonId { get; set; }
        public virtual Taxon TargetTaxon { get; set; }

        public Guid NodeTaxonId { get; set; }
        public virtual CladeTaxon NodeTaxon { get; set; }
    }

    [Obsolete("prototype")]
    public class CladeTaxonBranch : CladeTaxon
    {
        public Guid? ParentBranchId { get; set; }
        public virtual ICollection<CladeTaxonBranch> Branches { get; set; }

        public virtual ICollection<CladeTaxonNode> Nodes { get; set; }
    }

    [Obsolete("prototype")] // this table can be usefull on joins
    public class CladeTaxonNode : CladeTaxon
    {
        public Guid ParentBranchId { get; set; }
        public virtual CladeTaxonBranch ParentBranch { get; set; }

        public Guid DescendantBranchId { get; set; }
        public virtual CladeTaxonBranch DescendantBranch { get; set; }
    }
    #endregion    
}