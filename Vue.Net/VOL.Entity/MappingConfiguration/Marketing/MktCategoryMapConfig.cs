using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktCategoryMapConfig : EntityMappingConfiguration<MktCategory>
    {
        public override void Map(EntityTypeBuilder<MktCategory>
        builderTable)
        {
        }
    }
}
