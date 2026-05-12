using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_StrategyRepository : RepositoryBase<Sys_Strategy>, ISys_StrategyRepository
    {
        public Sys_StrategyRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_StrategyRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_StrategyRepository>(); }
        }
    }
}
