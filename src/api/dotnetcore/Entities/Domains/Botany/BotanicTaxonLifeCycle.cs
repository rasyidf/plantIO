using System;
using System.Collections.Generic;
using PlantIO.Entities.Taxonomy;

// #prototype: all classes in this namespace are currently for prototipal purposes
// view the js file in this folder for samples

namespace PlantIO.Botany
{
    public class BotanicTaxonLifeCycle : ITaxonReference
    {
        public Guid LifeCycleId { get; set; }
        public BotanicLifeCycle LifeCycle { get; set; }

        public int TaxonId { get; set; }
        public Taxon Taxon { get; set; }

        public int Order { get; set; } // review: 

        public TimeSpan AverageDuration { get; set; }

        public ICollection<BotanicFeature> Features { get; set; }

        public BotanicTaxonLifeCycle()
        {

        }
    }

    // it may be better to take life cycle on cultivar perspective, alternative/complementary to botanics: https://odells.typepad.com/blog/corn-growth-stages.html
    public class BotanicLifeCycle
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
    }

    [Obsolete("this class replaces property 'Order'... life cycles may be a state machine, considering that the plant changes the behaviour depending on environment / stress")]
    public class BotanicTaxonLifeCycleNode : ITaxonReference
    {
        public string Code { get; set; }

        public int TaxonId { get; set; }
        public Taxon Taxon { get; set; }
    }
}
