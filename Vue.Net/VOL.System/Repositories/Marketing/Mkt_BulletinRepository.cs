using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_BulletinRepository : RepositoryBase<MktBulletin>, IMkt_BulletinRepository
    {
        public Mkt_BulletinRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_BulletinRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_BulletinRepository>(); }
        }
    }
}
