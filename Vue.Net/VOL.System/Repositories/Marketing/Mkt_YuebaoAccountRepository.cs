using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_YuebaoAccountRepository : RepositoryBase<MktYuebaoAccount>, IMkt_YuebaoAccountRepository
    {
        public Mkt_YuebaoAccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_YuebaoAccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_YuebaoAccountRepository>(); }
        }
    }
}
