using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_NoticeRepository : RepositoryBase<MktNotice>, IMkt_NoticeRepository
    {
        public Mkt_NoticeRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_NoticeRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_NoticeRepository>(); }
        }
    }
}
