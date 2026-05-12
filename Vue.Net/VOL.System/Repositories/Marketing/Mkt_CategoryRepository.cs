using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_CategoryRepository : RepositoryBase<MktCategory>, IMkt_CategoryRepository
    {
        public Mkt_CategoryRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_CategoryRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_CategoryRepository>(); }
        }
    }
}
