using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_AppResourceService : ServiceBase<DC_AppResource, IDC_AppResourceRepository>
        , IDC_AppResourceService, IDependency
    {
        public static IDC_AppResourceService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_AppResourceService>(); } }
        }
    }
}
