using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Websites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class WebCustomerMapConfig : EntityMappingConfiguration<WebCustomer>
    {
        public override void Map(EntityTypeBuilder<WebCustomer> builderTable)
        {
        }
    }
}
