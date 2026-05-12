using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_WebCustomerRepository : RepositoryBase<DC_WebCustomer> , IDC_WebCustomerRepository
    {
        public DC_WebCustomerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_WebCustomerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_WebCustomerRepository>(); } }
        }
    }
}
