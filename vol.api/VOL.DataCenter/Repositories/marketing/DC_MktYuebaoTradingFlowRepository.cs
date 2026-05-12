using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktYuebaoTradingFlowRepository : RepositoryBase<DC_MktYuebaoTradingFlow> , IDC_MktYuebaoTradingFlowRepository
    {
        public DC_MktYuebaoTradingFlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktYuebaoTradingFlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktYuebaoTradingFlowRepository>(); } }
        }
    }
}
