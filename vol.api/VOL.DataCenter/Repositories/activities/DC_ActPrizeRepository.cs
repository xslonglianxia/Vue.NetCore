using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_ActPrizeRepository : RepositoryBase<DC_ActPrize> , IDC_ActPrizeRepository
    {
        public DC_ActPrizeRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_ActPrizeRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActPrizeRepository>(); } }
        }
    }
}
