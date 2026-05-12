using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_OrgMapConfig : EntityMappingConfiguration<Sys_Org>
    {
        public override void Map(EntityTypeBuilder<Sys_Org> builderTable)
        {
        }
    }
}
