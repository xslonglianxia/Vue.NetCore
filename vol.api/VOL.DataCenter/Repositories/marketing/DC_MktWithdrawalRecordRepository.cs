using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktWithdrawalRecordRepository : RepositoryBase<DC_MktWithdrawalRecord> , IDC_MktWithdrawalRecordRepository
    {
        public DC_MktWithdrawalRecordRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktWithdrawalRecordRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWithdrawalRecordRepository>(); } }
        }
    }
}
