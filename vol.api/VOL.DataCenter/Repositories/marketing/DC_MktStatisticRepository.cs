using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktStatisticRepository : RepositoryBase<DC_MktStatistic> , IDC_MktStatisticRepository
    {
        public DC_MktStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktStatisticRepository>(); } }
        }
    }
}
