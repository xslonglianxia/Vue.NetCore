using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktOrderDetailMapConfig : EntityMappingConfiguration<MktOrderDetail>
    {
        public override void Map(EntityTypeBuilder<MktOrderDetail>
        builderTable)
        {
        }
    }
}
