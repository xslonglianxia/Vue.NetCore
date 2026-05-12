using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktNoticeRepository : RepositoryBase<DC_MktNotice> , IDC_MktNoticeRepository
    {
        public DC_MktNoticeRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktNoticeRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktNoticeRepository>(); } }
        }
    }
}
