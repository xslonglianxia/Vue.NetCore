using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Points;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class PtsAccountMapConfig : EntityMappingConfiguration<PtsAccount>
    {
        public override void Map(EntityTypeBuilder<PtsAccount> builderTable)
        {
        }
    }
}
