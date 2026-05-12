using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysPositionRepository : RepositoryBase<DC_SysPosition> , IDC_SysPositionRepository
    {
        public DC_SysPositionRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysPositionRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysPositionRepository>(); } }
        }
    }
}
