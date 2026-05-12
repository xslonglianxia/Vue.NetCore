using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktPerformanceStatisticRepository : RepositoryBase<DC_MktPerformanceStatistic> , IDC_MktPerformanceStatisticRepository
    {
        public DC_MktPerformanceStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktPerformanceStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktPerformanceStatisticRepository>(); } }
        }
    }
}
