using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktMemberLoginLogService : ServiceBase<DC_MktMemberLoginLog, IDC_MktMemberLoginLogRepository>
        , IDC_MktMemberLoginLogService, IDependency
    {
        public static IDC_MktMemberLoginLogService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberLoginLogService>(); } }
        }
    }
}
