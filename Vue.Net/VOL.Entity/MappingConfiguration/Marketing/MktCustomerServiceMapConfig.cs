using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktCustomerServiceMapConfig : EntityMappingConfiguration<MktCustomerService>
    {
        public override void Map(EntityTypeBuilder<MktCustomerService>
        builderTable)
        {
        }
    }
}
