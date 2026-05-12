using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_OrderDetailRepository : RepositoryBase<MktOrderDetail>, IMkt_OrderDetailRepository
    {
        public Mkt_OrderDetailRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_OrderDetailRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_OrderDetailRepository>(); }
        }
    }
}
