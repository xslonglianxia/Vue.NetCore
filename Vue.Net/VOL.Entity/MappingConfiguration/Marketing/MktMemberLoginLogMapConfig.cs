using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktMemberLoginLogMapConfig : EntityMappingConfiguration<MktMemberLoginLog>
    {
        public override void Map(EntityTypeBuilder<MktMemberLoginLog>
        builderTable)
        {
        }
    }
}
