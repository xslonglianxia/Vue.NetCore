using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_PerformanceStatisticRepository : RepositoryBase<MktPerformanceStatistic>, IMkt_PerformanceStatisticRepository
    {
        public Mkt_PerformanceStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_PerformanceStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_PerformanceStatisticRepository>(); }
        }
    }
}
