using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysOrgService : ServiceBase<DC_SysOrg, IDC_SysOrgRepository>
        , IDC_SysOrgService, IDependency
    {
        public static IDC_SysOrgService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysOrgService>(); } }
        }
    }
}
