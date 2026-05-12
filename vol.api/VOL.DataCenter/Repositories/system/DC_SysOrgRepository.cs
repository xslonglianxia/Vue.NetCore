using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysOrgRepository : RepositoryBase<DC_SysOrg> , IDC_SysOrgRepository
    {
        public DC_SysOrgRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysOrgRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysOrgRepository>(); } }
        }
    }
}
