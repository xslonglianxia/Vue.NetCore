using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysUserLoginLogService : ServiceBase<DC_SysUserLoginLog, IDC_SysUserLoginLogRepository>
        , IDC_SysUserLoginLogService, IDependency
    {
        public static IDC_SysUserLoginLogService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysUserLoginLogService>(); } }
        }
    }
}
