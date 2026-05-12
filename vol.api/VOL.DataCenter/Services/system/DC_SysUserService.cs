using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysUserService : ServiceBase<DC_SysUser, IDC_SysUserRepository>
        , IDC_SysUserService, IDependency
    {
        public static IDC_SysUserService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysUserService>(); } }
        }
    }
}
