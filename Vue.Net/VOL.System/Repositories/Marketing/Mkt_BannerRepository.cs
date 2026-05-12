using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_BannerRepository : RepositoryBase<MktBanner>, IMkt_BannerRepository
    {
        public Mkt_BannerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_BannerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_BannerRepository>(); }
        }
    }
}
