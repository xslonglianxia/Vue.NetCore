using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysOperationLogService : ServiceBase<DC_SysOperationLog, IDC_SysOperationLogRepository>
        , IDC_SysOperationLogService, IDependency
    {
        public static IDC_SysOperationLogService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysOperationLogService>(); } }
        }
    }
}
