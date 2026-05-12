using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktSettingMapConfig : EntityMappingConfiguration<MktSetting>
    {
        public override void Map(EntityTypeBuilder<MktSetting>
        builderTable)
        {
        }
    }
}
