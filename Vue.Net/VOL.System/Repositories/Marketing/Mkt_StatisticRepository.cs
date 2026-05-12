using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_StatisticRepository : RepositoryBase<MktStatistic>, IMkt_StatisticRepository
    {
        public Mkt_StatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_StatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_StatisticRepository>(); }
        }
    }
}
