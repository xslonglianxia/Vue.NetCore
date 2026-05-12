using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktMemberStatisticMapConfig : EntityMappingConfiguration<MktMemberStatistic>
    {
        public override void Map(EntityTypeBuilder<MktMemberStatistic>
        builderTable)
        {
        }
    }
}
