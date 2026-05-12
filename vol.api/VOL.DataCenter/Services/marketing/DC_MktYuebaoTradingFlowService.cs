using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktYuebaoTradingFlowService : ServiceBase<DC_MktYuebaoTradingFlow, IDC_MktYuebaoTradingFlowRepository>
        , IDC_MktYuebaoTradingFlowService, IDependency
    {
        public static IDC_MktYuebaoTradingFlowService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktYuebaoTradingFlowService>(); } }
        }
    }
}
