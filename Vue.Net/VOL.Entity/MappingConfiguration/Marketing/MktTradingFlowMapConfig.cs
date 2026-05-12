using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktTradingFlowMapConfig : EntityMappingConfiguration<MktTradingFlow>
    {
        public override void Map(EntityTypeBuilder<MktTradingFlow>
        builderTable)
        {
        }
    }
}
