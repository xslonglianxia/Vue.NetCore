using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_PositionRepository : RepositoryBase<Sys_Position>, ISys_PositionRepository
    {
        public Sys_PositionRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_PositionRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_PositionRepository>(); }
        }
    }
}
