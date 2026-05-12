using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Activities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class ActAccountMapConfig : EntityMappingConfiguration<ActAccount>
    {
        public override void Map(EntityTypeBuilder<ActAccount> builderTable)
        {
        }
    }
}
