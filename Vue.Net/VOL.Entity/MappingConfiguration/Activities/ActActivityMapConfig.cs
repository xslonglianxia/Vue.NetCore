using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Activities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class ActActivityMapConfig : EntityMappingConfiguration<ActActivity>
    {
        public override void Map(EntityTypeBuilder<ActActivity> builderTable)
        {
        }
    }
}
