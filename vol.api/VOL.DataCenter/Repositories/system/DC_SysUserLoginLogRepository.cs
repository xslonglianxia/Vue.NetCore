using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysUserLoginLogRepository : RepositoryBase<DC_SysUserLoginLog> , IDC_SysUserLoginLogRepository
    {
        public DC_SysUserLoginLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysUserLoginLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysUserLoginLogRepository>(); } }
        }
    }
}
