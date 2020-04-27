using Microsoft.EntityFrameworkCore;
using PlantIO.Entities.Taxonomy;

namespace PlantIO.Botany.Data.EntityFramework
{
    public static class BotanyEntityTypeConfigurator
    {
        public static void ConfigureBotany<TDbContext>(TDbContext context, ModelBuilder modelBuilder)
            where TDbContext : IBotanyDbContext
        {
            var botanicFeature = modelBuilder.Entity<BotanicFeature>();

            botanicFeature.HasKey(f => f.Id);

            var taxonBotanicFeature = modelBuilder.Entity<TaxonBotanicFeature>();
            taxonBotanicFeature
                .HasOne(t => t.BotanicFeature)
                .WithMany(bf => bf.TaxonRelations)
                .HasForeignKey(bf => bf.BotanicFeatureId);
            taxonBotanicFeature
                .HasMany(t => t.RangeValues)
                .WithOne(rv => rv.Feature)
                .HasForeignKey(bf => bf.FeatureId);

            var botanicFeatureRange = modelBuilder.Entity<BotanicFeatureRange>();
            botanicFeatureRange.HasKey(bf => bf.Id);
            botanicFeatureRange
                .HasOne(t => t.Feature)
                .WithMany(bf => bf.RangeValues)
                .HasForeignKey(bf => bf.FeatureId);
            
            var botanicLifeCycle = modelBuilder.Ignore<BotanicTaxonLifeCycle>();
        }
    }
}
