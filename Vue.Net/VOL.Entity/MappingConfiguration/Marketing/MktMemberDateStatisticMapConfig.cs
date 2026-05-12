using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktMemberDateStatisticMapConfig : EntityMappingConfiguration<MktMemberDateStatistic>
    {
        public override void Map(EntityTypeBuilder<MktMemberDateStatistic>
        builderTable)
        {
        }
    }
}
