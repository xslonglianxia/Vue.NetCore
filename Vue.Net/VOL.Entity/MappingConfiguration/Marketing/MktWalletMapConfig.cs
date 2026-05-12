using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktWalletMapConfig : EntityMappingConfiguration<MktWallet>
    {
        public override void Map(EntityTypeBuilder<MktWallet>
        builderTable)
        {
        }
    }
}
