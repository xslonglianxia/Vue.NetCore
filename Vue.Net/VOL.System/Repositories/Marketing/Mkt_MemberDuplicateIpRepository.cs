using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_MemberDuplicateIpRepository : RepositoryBase<MktMemberDuplicateIp>, IMkt_MemberDuplicateIpRepository
    {
        public Mkt_MemberDuplicateIpRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_MemberDuplicateIpRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_MemberDuplicateIpRepository>(); }
        }
    }
}
