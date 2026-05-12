using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktBannerRepository : RepositoryBase<DC_MktBanner> , IDC_MktBannerRepository
    {
        public DC_MktBannerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktBannerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktBannerRepository>(); } }
        }
    }
}
