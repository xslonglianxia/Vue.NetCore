using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_AppAppService : ServiceBase<DC_AppApp, IDC_AppAppRepository>
        , IDC_AppAppService, IDependency
    {
        public static IDC_AppAppService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_AppAppService>(); } }
        }
    }
}
