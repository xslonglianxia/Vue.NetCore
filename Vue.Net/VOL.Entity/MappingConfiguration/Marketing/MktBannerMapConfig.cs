using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktBannerMapConfig : EntityMappingConfiguration<MktBanner>
    {
        public override void Map(EntityTypeBuilder<MktBanner>
        builderTable)
        {
        }
    }
}
