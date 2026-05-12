using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktNoticeMapConfig : EntityMappingConfiguration<MktNotice>
    {
        public override void Map(EntityTypeBuilder<MktNotice>
        builderTable)
        {
        }
    }
}
