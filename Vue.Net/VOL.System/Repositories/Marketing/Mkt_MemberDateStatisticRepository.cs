using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_MemberDateStatisticRepository : RepositoryBase<MktMemberDateStatistic>, IMkt_MemberDateStatisticRepository
    {
        public Mkt_MemberDateStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_MemberDateStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_MemberDateStatisticRepository>(); }
        }
    }
}
