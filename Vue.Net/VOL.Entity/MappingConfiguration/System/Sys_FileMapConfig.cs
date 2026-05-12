using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_FileMapConfig : EntityMappingConfiguration<Sys_File>
    {
        public override void Map(EntityTypeBuilder<Sys_File> builderTable)
        {
        }
    }
}
