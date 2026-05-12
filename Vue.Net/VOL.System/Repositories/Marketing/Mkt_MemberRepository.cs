using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_MemberRepository : RepositoryBase<MktMember>, IMkt_MemberRepository
    {
        public Mkt_MemberRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_MemberRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_MemberRepository>(); }
        }
    }
}
