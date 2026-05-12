using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_YuebaoTradingFlowRepository : RepositoryBase<MktYuebaoTradingFlow>, IMkt_YuebaoTradingFlowRepository
    {
        public Mkt_YuebaoTradingFlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_YuebaoTradingFlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_YuebaoTradingFlowRepository>(); }
        }
    }
}
