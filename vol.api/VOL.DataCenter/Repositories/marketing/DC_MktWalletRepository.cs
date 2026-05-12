using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktWalletRepository : RepositoryBase<DC_MktWallet> , IDC_MktWalletRepository
    {
        public DC_MktWalletRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktWalletRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWalletRepository>(); } }
        }
    }
}
