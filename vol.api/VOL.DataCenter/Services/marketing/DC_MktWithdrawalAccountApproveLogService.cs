using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktWithdrawalAccountApproveLogService : ServiceBase<DC_MktWithdrawalAccountApproveLog, IDC_MktWithdrawalAccountApproveLogRepository>
        , IDC_MktWithdrawalAccountApproveLogService, IDependency
    {
        public static IDC_MktWithdrawalAccountApproveLogService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalAccountApproveLogService>(); } }
        }
    }
}
