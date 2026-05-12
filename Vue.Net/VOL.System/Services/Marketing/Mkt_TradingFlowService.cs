using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_TradingFlowService : ServiceBase<MktTradingFlow, IMkt_TradingFlowRepository>, IMkt_TradingFlowService, IDependency
    {
        public Mkt_TradingFlowService(IMkt_TradingFlowRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_TradingFlowService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_TradingFlowService>(); }
        }
    }
}
