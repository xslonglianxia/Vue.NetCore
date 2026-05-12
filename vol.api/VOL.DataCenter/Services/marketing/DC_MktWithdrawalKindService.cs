using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktWithdrawalKindService : ServiceBase<DC_MktWithdrawalKind, IDC_MktWithdrawalKindRepository>
        , IDC_MktWithdrawalKindService, IDependency
    {
        public static IDC_MktWithdrawalKindService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalKindService>(); } }
        }
    }
}
