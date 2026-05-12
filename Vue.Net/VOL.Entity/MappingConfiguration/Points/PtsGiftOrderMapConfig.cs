using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Points;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class PtsGiftOrderMapConfig : EntityMappingConfiguration<PtsGiftOrder>
    {
        public override void Map(EntityTypeBuilder<PtsGiftOrder> builderTable)
        {
        }
    }
}
