using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysStrategyRepository : RepositoryBase<DC_SysStrategy> , IDC_SysStrategyRepository
    {
        public DC_SysStrategyRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysStrategyRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysStrategyRepository>(); } }
        }
    }
}
