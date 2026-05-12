using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Sys_OperationLogMapConfig : EntityMappingConfiguration<Sys_OperationLog>
    {
        public override void Map(EntityTypeBuilder<Sys_OperationLog> builderTable)
        {
        }
    }
}
