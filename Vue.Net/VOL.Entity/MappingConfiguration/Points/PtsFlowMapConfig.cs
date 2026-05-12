using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Points;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class PtsFlowMapConfig : EntityMappingConfiguration<PtsFlow>
    {
        public override void Map(EntityTypeBuilder<PtsFlow> builderTable)
        {
        }
    }
}
