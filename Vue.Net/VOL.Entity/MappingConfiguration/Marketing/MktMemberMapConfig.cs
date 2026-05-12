using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktMemberMapConfig : EntityMappingConfiguration<MktMember>
    {
        public override void Map(EntityTypeBuilder<MktMember>
        builderTable)
        {
        }
    }
}
