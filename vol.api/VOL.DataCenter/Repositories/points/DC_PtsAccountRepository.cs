using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_PtsAccountRepository : RepositoryBase<DC_PtsAccount> , IDC_PtsAccountRepository
    {
        public DC_PtsAccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_PtsAccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsAccountRepository>(); } }
        }
    }
}
