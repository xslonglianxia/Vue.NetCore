using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_WithdrawalAccountApproveLogService : ServiceBase<MktWithdrawalAccountApproveLog, IMkt_WithdrawalAccountApproveLogRepository>, IMkt_WithdrawalAccountApproveLogService, IDependency
    {
        public Mkt_WithdrawalAccountApproveLogService(IMkt_WithdrawalAccountApproveLogRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_WithdrawalAccountApproveLogService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_WithdrawalAccountApproveLogService>(); }
        }
    }
}
