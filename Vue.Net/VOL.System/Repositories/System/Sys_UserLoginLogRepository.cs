using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_UserLoginLogRepository : RepositoryBase<Sys_UserLoginLog>, ISys_UserLoginLogRepository
    {
        public Sys_UserLoginLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_UserLoginLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_UserLoginLogRepository>(); }
        }
    }
}
