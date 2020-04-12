using System;
namespace Entities.Spatial
{
    public class Land
    {
        public static readonly Guid Nature = Guid.Empty;

        public Guid Id { get; set; }

        public Guid? LandLordId { get; set; } = Nature;
        
        public Guid? LandTenantId { get; set; }

        public object Position { get; set; }

        public Guid MacroRegionId { get; set; }
        public MacroRegion MacroRegion { get; set; }
    }

    public class Lot
    {
        public Guid LandId { get; set; }

        public int? TenantId { get; set; }
    }
}