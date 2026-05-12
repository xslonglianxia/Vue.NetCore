using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_PtsFlowRepository : RepositoryBase<DC_PtsFlow> , IDC_PtsFlowRepository
    {
        public DC_PtsFlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_PtsFlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsFlowRepository>(); } }
        }
    }
}
