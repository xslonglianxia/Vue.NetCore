using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktOrderDetailRepository : RepositoryBase<DC_MktOrderDetail> , IDC_MktOrderDetailRepository
    {
        public DC_MktOrderDetailRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktOrderDetailRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktOrderDetailRepository>(); } }
        }
    }
}
