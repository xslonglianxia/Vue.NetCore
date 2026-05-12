using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktCategoryRepository : RepositoryBase<DC_MktCategory> , IDC_MktCategoryRepository
    {
        public DC_MktCategoryRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktCategoryRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktCategoryRepository>(); } }
        }
    }
}
