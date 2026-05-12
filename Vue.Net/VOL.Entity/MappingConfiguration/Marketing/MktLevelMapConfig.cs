using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktLevelMapConfig : EntityMappingConfiguration<MktLevel>
    {
        public override void Map(EntityTypeBuilder<MktLevel>
        builderTable)
        {
        }
    }
}
