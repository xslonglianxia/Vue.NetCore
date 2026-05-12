using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.Points;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class PtsGiftMapConfig : EntityMappingConfiguration<PtsGift>
    {
        public override void Map(EntityTypeBuilder<PtsGift> builderTable)
        {
        }
    }
}
