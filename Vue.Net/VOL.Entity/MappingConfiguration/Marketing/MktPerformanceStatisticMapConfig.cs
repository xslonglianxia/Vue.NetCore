using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktPerformanceStatisticMapConfig : EntityMappingConfiguration<MktPerformanceStatistic>
    {
        public override void Map(EntityTypeBuilder<MktPerformanceStatistic>
        builderTable)
        {
        }
    }
}
