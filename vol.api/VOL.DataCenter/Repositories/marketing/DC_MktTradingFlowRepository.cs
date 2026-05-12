using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktTradingFlowRepository : RepositoryBase<DC_MktTradingFlow> , IDC_MktTradingFlowRepository
    {
        public DC_MktTradingFlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktTradingFlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktTradingFlowRepository>(); } }
        }
    }
}
