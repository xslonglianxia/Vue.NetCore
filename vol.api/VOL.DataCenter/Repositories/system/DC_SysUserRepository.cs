using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysUserRepository : RepositoryBase<DC_SysUser> , IDC_SysUserRepository
    {
        public DC_SysUserRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysUserRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysUserRepository>(); } }
        }
    }
}
