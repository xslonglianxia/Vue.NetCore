using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktMemberDateStatisticRepository : RepositoryBase<DC_MktMemberDateStatistic> , IDC_MktMemberDateStatisticRepository
    {
        public DC_MktMemberDateStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktMemberDateStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberDateStatisticRepository>(); } }
        }
    }
}
