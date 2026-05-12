using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktLevelRepository : RepositoryBase<DC_MktLevel> , IDC_MktLevelRepository
    {
        public DC_MktLevelRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktLevelRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktLevelRepository>(); } }
        }
    }
}
