using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktMemberDuplicateIpMapConfig : EntityMappingConfiguration<MktMemberDuplicateIp>
    {
        public override void Map(EntityTypeBuilder<MktMemberDuplicateIp>
        builderTable)
        {
        }
    }
}
