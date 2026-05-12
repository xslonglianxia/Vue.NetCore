using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_GroupMapConfig : EntityMappingConfiguration<Sys_Group>
    {
        public override void Map(EntityTypeBuilder<Sys_Group> builderTable)
        {
        }
    }
}
