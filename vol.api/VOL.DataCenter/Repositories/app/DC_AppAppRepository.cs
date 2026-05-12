using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_AppAppRepository : RepositoryBase<DC_AppApp> , IDC_AppAppRepository
    {
        public DC_AppAppRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_AppAppRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_AppAppRepository>(); } }
        }
    }
}
