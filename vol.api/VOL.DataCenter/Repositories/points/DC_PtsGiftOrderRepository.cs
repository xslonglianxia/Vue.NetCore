using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_PtsGiftOrderRepository : RepositoryBase<DC_PtsGiftOrder> , IDC_PtsGiftOrderRepository
    {
        public DC_PtsGiftOrderRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_PtsGiftOrderRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsGiftOrderRepository>(); } }
        }
    }
}
