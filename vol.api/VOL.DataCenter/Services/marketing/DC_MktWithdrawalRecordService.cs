using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktWithdrawalRecordService : ServiceBase<DC_MktWithdrawalRecord, IDC_MktWithdrawalRecordRepository>
        , IDC_MktWithdrawalRecordService, IDependency
    {
        public static IDC_MktWithdrawalRecordService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalRecordService>(); } }
        }
    }
}
