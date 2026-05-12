using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktRechargeRecordService : ServiceBase<DC_MktRechargeRecord, IDC_MktRechargeRecordRepository>
        , IDC_MktRechargeRecordService, IDependency
    {
        public static IDC_MktRechargeRecordService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktRechargeRecordService>(); } }
        }
    }
}
