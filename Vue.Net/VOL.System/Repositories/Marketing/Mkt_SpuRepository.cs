using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_SpuRepository : RepositoryBase<MktSpu>, IMkt_SpuRepository
    {
        public Mkt_SpuRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_SpuRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_SpuRepository>(); }
        }
    }
}
