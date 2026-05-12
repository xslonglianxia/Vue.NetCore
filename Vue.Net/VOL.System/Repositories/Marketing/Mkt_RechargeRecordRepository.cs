using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_RechargeRecordRepository : RepositoryBase<MktRechargeRecord>, IMkt_RechargeRecordRepository
    {
        public Mkt_RechargeRecordRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_RechargeRecordRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_RechargeRecordRepository>(); }
        }
    }
}
