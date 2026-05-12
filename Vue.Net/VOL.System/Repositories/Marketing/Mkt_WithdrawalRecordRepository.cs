using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_WithdrawalRecordRepository : RepositoryBase<MktWithdrawalRecord>, IMkt_WithdrawalRecordRepository
    {
        public Mkt_WithdrawalRecordRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_WithdrawalRecordRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_WithdrawalRecordRepository>(); }
        }
    }
}
