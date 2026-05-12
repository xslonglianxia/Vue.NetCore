using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysPositionService : ServiceBase<DC_SysPosition, IDC_SysPositionRepository>
        , IDC_SysPositionService, IDependency
    {
        public static IDC_SysPositionService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysPositionService>(); } }
        }
    }
}
