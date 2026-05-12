using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_TradingFlowRepository : RepositoryBase<MktTradingFlow>, IMkt_TradingFlowRepository
    {
        public Mkt_TradingFlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_TradingFlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_TradingFlowRepository>(); }
        }
    }
}
