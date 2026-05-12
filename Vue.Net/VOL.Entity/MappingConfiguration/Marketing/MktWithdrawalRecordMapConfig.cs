using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Marketing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class MktWithdrawalRecordMapConfig : EntityMappingConfiguration<MktWithdrawalRecord>
    {
        public override void Map(EntityTypeBuilder<MktWithdrawalRecord>
        builderTable)
        {
        }
    }
}
