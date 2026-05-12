using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysFileRepository : RepositoryBase<DC_SysFile> , IDC_SysFileRepository
    {
        public DC_SysFileRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysFileRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysFileRepository>(); } }
        }
    }
}
