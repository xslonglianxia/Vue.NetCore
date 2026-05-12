using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktMemberLoginLogRepository : RepositoryBase<DC_MktMemberLoginLog> , IDC_MktMemberLoginLogRepository
    {
        public DC_MktMemberLoginLogRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktMemberLoginLogRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberLoginLogRepository>(); } }
        }
    }
}
