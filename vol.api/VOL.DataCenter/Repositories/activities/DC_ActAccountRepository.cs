using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_ActAccountRepository : RepositoryBase<DC_ActAccount> , IDC_ActAccountRepository
    {
        public DC_ActAccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_ActAccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActAccountRepository>(); } }
        }
    }
}
