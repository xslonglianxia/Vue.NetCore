using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_WithdrawalAccountApproveLogRepository : RepositoryBase<MktWithdrawalAccountApproveLog>, IMkt_WithdrawalAccountApproveLogRepository
    {
        public Mkt_WithdrawalAccountApproveLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_WithdrawalAccountApproveLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_WithdrawalAccountApproveLogRepository>(); }
        }
    }
}
