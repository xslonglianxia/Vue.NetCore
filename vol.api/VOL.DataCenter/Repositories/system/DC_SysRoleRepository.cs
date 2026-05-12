using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysRoleRepository : RepositoryBase<DC_SysRole> , IDC_SysRoleRepository
    {
        public DC_SysRoleRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysRoleRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysRoleRepository>(); } }
        }
    }
}
