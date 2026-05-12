using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktCustomerServiceRepository : RepositoryBase<DC_MktCustomerService> , IDC_MktCustomerServiceRepository
    {
        public DC_MktCustomerServiceRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktCustomerServiceRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktCustomerServiceRepository>(); } }
        }
    }
}
