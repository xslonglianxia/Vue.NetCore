using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysOperationLogRepository : RepositoryBase<DC_SysOperationLog> , IDC_SysOperationLogRepository
    {
        public DC_SysOperationLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysOperationLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysOperationLogRepository>(); } }
        }
    }
}
