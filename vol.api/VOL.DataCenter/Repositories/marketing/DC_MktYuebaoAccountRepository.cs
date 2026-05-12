using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktYuebaoAccountRepository : RepositoryBase<DC_MktYuebaoAccount> , IDC_MktYuebaoAccountRepository
    {
        public DC_MktYuebaoAccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktYuebaoAccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktYuebaoAccountRepository>(); } }
        }
    }
}
