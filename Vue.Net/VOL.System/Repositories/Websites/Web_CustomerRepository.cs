using VOL.System.IRepositories.Websites;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Websites;

namespace VOL.System.Repositories.Websites
{
    public partial class Web_CustomerRepository : RepositoryBase<WebCustomer>, IWeb_CustomerRepository
    {
        public Web_CustomerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IWeb_CustomerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IWeb_CustomerRepository>(); }
        }
    }
}
