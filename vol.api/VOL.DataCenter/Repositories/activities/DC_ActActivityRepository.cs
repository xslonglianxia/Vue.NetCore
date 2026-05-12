using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_ActActivityRepository : RepositoryBase<DC_ActActivity> , IDC_ActActivityRepository
    {
        public DC_ActActivityRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_ActActivityRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActActivityRepository>(); } }
        }
    }
}
