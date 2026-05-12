using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_OperationLogRepository : RepositoryBase<Sys_OperationLog>, ISys_OperationLogRepository
    {
        public Sys_OperationLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_OperationLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_OperationLogRepository>(); }
        }
    }
}
