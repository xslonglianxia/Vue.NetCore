using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysRoleService : ServiceBase<DC_SysRole, IDC_SysRoleRepository>
        , IDC_SysRoleService, IDependency
    {
        public static IDC_SysRoleService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysRoleService>(); } }
        }
    }
}
