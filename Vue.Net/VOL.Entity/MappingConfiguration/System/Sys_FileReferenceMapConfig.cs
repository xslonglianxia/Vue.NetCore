using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_FileReferenceMapConfig : EntityMappingConfiguration<Sys_FileReference>
    {
        public override void Map(EntityTypeBuilder<Sys_FileReference> builderTable)
        {
        }
    }
}
