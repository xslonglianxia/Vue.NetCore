using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktRecruitmentRepository : RepositoryBase<DC_MktRecruitment> , IDC_MktRecruitmentRepository
    {
        public DC_MktRecruitmentRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktRecruitmentRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktRecruitmentRepository>(); } }
        }
    }
}
