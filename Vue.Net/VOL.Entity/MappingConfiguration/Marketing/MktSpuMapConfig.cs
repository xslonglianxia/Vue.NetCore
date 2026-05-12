using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktSpuMapConfig : EntityMappingConfiguration<MktSpu>
    {
        public override void Map(EntityTypeBuilder<MktSpu>
        builderTable)
        {
        }
    }
}
