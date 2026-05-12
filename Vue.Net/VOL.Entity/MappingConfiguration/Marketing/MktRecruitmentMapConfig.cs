using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktRecruitmentMapConfig : EntityMappingConfiguration<MktRecruitment>
    {
        public override void Map(EntityTypeBuilder<MktRecruitment>
        builderTable)
        {
        }
    }
}
