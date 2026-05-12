using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktBulletinMapConfig : EntityMappingConfiguration<MktBulletin>
    {
        public override void Map(EntityTypeBuilder<MktBulletin>
        builderTable)
        {
        }
    }
}
