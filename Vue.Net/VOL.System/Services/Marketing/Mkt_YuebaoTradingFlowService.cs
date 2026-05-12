using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_YuebaoTradingFlowService : ServiceBase<MktYuebaoTradingFlow, IMkt_YuebaoTradingFlowRepository>, IMkt_YuebaoTradingFlowService, IDependency
    {
        public Mkt_YuebaoTradingFlowService(IMkt_YuebaoTradingFlowRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_YuebaoTradingFlowService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_YuebaoTradingFlowService>(); }
        }
    }
}
