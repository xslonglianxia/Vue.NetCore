using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Activities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class ActPartnerMapConfig : EntityMappingConfiguration<ActPartner>
    {
        public override void Map(EntityTypeBuilder<ActPartner> builderTable)
        {
        }
    }
}
