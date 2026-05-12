using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktWithdrawalAccountApproveLogRepository : RepositoryBase<DC_MktWithdrawalAccountApproveLog> , IDC_MktWithdrawalAccountApproveLogRepository
    {
        public DC_MktWithdrawalAccountApproveLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktWithdrawalAccountApproveLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalAccountApproveLogRepository>(); } }
        }
    }
}
