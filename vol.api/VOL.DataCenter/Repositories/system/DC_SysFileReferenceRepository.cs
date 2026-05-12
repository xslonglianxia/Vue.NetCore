using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_SysFileReferenceRepository : RepositoryBase<DC_SysFileReference> , IDC_SysFileReferenceRepository
    {
        public DC_SysFileReferenceRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_SysFileReferenceRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysFileReferenceRepository>(); } }
        }
    }
}
