using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_WalletRepository : RepositoryBase<MktWallet>, IMkt_WalletRepository
    {
        public Mkt_WalletRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_WalletRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_WalletRepository>(); }
        }
    }
}
