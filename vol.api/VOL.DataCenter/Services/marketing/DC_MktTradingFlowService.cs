using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktTradingFlowService : ServiceBase<DC_MktTradingFlow, IDC_MktTradingFlowRepository>
        , IDC_MktTradingFlowService, IDependency
    {
        public static IDC_MktTradingFlowService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktTradingFlowService>(); } }
        }
    }
}
