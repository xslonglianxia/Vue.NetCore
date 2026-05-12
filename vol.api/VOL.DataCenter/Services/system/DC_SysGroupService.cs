using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysGroupService : ServiceBase<DC_SysGroup, IDC_SysGroupRepository>
        , IDC_SysGroupService, IDependency
    {
        public static IDC_SysGroupService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysGroupService>(); } }
        }
    }
}
