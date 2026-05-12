using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktWithdrawalKindRepository : RepositoryBase<DC_MktWithdrawalKind> , IDC_MktWithdrawalKindRepository
    {
        public DC_MktWithdrawalKindRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktWithdrawalKindRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalKindRepository>(); } }
        }
    }
}
