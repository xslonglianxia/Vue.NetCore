using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktRechargeRecordRepository : RepositoryBase<DC_MktRechargeRecord> , IDC_MktRechargeRecordRepository
    {
        public DC_MktRechargeRecordRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktRechargeRecordRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktRechargeRecordRepository>(); } }
        }
    }
}
