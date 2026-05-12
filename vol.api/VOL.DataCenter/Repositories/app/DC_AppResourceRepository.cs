using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_AppResourceRepository : RepositoryBase<DC_AppResource> , IDC_AppResourceRepository
    {
        public DC_AppResourceRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_AppResourceRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_AppResourceRepository>(); } }
        }
    }
}
