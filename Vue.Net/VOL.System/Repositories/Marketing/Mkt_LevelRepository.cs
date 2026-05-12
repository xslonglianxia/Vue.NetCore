using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_LevelRepository : RepositoryBase<MktLevel>, IMkt_LevelRepository
    {
        public Mkt_LevelRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_LevelRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_LevelRepository>(); }
        }
    }
}
