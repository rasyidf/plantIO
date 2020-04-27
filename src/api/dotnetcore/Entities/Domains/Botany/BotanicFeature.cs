using System;
using System.Collections.Generic;
using PlantIO.Entities;
using PlantIO.Entities.Taxonomy;

// 🚧 #PROTOTYPE:

namespace PlantIO.Botany
{
    // refactor: that could be specific classes for each one of those fields
    // those data should vary acording to region and dataset, but maybe only on cultivar layer
    // > consider using not-only SQL

    // defines a variable that stores morphology, phenology, agricultural characteristics, etc...
    public class BotanicFeature
    {
        public Guid Id { get; set; }

        /// <summary>
        /// A standard code for characteristc name, 
        /// for instance, "🌞"  would be the code for both
        /// "en|sun" and "pt|sol"
        /// </summary>
        public string Identifier { get; set; }

        public BotanicFeature() { }
        public BotanicFeature(string identifier)
        {
            Identifier = identifier;
            Id = Guid.NewGuid();
        }

        public virtual ICollection<TaxonBotanicFeature> TaxonRelations { get; set; }

        public static readonly BotanicFeature SoilMoisture = new BotanicFeature("soil-moisture");
        public static readonly BotanicFeature PotentialOfHydrogen = new BotanicFeature("PH");
        public static readonly BotanicFeature Strata = new BotanicFeature("strata");
    }

    public class TaxonBotanicFeature : ITaxonReference
    {
        public int Id { get; set; }

        public int TaxonId { get; set; }
        public Taxon Taxon { get; set; }

        public Guid BotanicFeatureId { get; set; }
        public BotanicFeature BotanicFeature { get; set; }

        public virtual ICollection<BotanicFeatureRange> RangeValues { get; set; }

        public string Value { get; set; }
    }

    public class BotanicFeatureRange : IMultiDataSetRegionalData
    {
        public int Id { get; set; }

        public Guid? DataSetId { get; set; }
        public Guid? RegionId { get; set; }

        public int FeatureId { get; set; }
        public TaxonBotanicFeature Feature { get; set; }

        public FeatureRangeTypes Types { get; set; }

        int? Min { get; set; }
        int? Max { get; set; }
        int Fit { get; set; }

        public BotanicFeatureRange() { }
        public BotanicFeatureRange(int taxonBotanicFeatureId, TaxonBotanicFeature taxonBotanicFeature, FeatureRangeTypes types)
        {
            this.FeatureId = taxonBotanicFeatureId;
            this.Feature = taxonBotanicFeature;
            this.Types = types;
        }
        public BotanicFeatureRange(TaxonBotanicFeature taxonBotanicFeature, int fit, int min, int max, FeatureRangeTypes types = 0)
        {
            Feature = taxonBotanicFeature;
            Fit = fit;
            Min = min;
            Max = max;
        }
    }

    public enum FeatureRangeTypes
    {
        Range = 0,
        Subtraction = 1,
        QuadracticGraph = 2, // fit is vertex
        Sum = 4,
    }

    public interface IMathematicalCultivarCharacteristic //: ICultivarCharacteristic
    {
        string FunctionName { get; set; }
        Dictionary<string, object> Arguments { get; set; }
    }
}
