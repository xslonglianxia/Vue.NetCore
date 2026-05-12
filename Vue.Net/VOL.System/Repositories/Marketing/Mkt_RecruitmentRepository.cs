using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_RecruitmentRepository : RepositoryBase<MktRecruitment>, IMkt_RecruitmentRepository
    {
        public Mkt_RecruitmentRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_RecruitmentRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_RecruitmentRepository>(); }
        }
    }
}
