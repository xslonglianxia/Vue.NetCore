using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_MemberStatisticRepository : RepositoryBase<MktMemberStatistic>, IMkt_MemberStatisticRepository
    {
        public Mkt_MemberStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_MemberStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_MemberStatisticRepository>(); }
        }
    }
}
