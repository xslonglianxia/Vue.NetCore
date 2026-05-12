using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_WithdrawalKindRepository : RepositoryBase<MktWithdrawalKind>, IMkt_WithdrawalKindRepository
    {
        public Mkt_WithdrawalKindRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_WithdrawalKindRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_WithdrawalKindRepository>(); }
        }
    }
}
