using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktMemberStatisticRepository : RepositoryBase<DC_MktMemberStatistic> , IDC_MktMemberStatisticRepository
    {
        public DC_MktMemberStatisticRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktMemberStatisticRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberStatisticRepository>(); } }
        }
    }
}
