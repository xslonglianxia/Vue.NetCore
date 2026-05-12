using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_MemberLoginLogRepository : RepositoryBase<MktMemberLoginLog>, IMkt_MemberLoginLogRepository
    {
        public Mkt_MemberLoginLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_MemberLoginLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_MemberLoginLogRepository>(); }
        }
    }
}
