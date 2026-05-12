using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_PositionMapConfig : EntityMappingConfiguration<Sys_Position>
    {
        public override void Map(EntityTypeBuilder<Sys_Position> builderTable)
        {
        }
    }
}
