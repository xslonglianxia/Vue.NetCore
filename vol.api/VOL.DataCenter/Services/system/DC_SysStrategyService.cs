using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysStrategyService : ServiceBase<DC_SysStrategy, IDC_SysStrategyRepository>
        , IDC_SysStrategyService, IDependency
    {
        public static IDC_SysStrategyService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysStrategyService>(); } }
        }
    }
}
