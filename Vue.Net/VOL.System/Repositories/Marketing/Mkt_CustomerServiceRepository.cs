using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_CustomerServiceRepository : RepositoryBase<MktCustomerService>, IMkt_CustomerServiceRepository
    {
        public Mkt_CustomerServiceRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_CustomerServiceRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_CustomerServiceRepository>(); }
        }
    }
}
