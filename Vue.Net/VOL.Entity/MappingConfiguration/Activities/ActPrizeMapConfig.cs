using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Activities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class ActPrizeMapConfig : EntityMappingConfiguration<ActPrize>
    {
        public override void Map(EntityTypeBuilder<ActPrize> builderTable)
        {
        }
    }
}
