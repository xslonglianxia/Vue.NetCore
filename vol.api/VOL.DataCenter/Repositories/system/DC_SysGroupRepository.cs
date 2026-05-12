using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysGroupRepository : RepositoryBase<DC_SysGroup> , IDC_SysGroupRepository
    {
        public DC_SysGroupRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysGroupRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysGroupRepository>(); } }
        }
    }
}
