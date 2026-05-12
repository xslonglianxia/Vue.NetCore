using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_PtsGiftRepository : RepositoryBase<DC_PtsGift> , IDC_PtsGiftRepository
    {
        public DC_PtsGiftRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_PtsGiftRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsGiftRepository>(); } }
        }
    }
}
