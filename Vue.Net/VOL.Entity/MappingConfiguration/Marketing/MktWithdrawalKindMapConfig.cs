using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktWithdrawalKindMapConfig : EntityMappingConfiguration<MktWithdrawalKind>
    {
        public override void Map(EntityTypeBuilder<MktWithdrawalKind>
        builderTable)
        {
        }
    }
}
