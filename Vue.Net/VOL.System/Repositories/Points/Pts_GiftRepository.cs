using VOL.System.IRepositories.Points;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Repositories.Points
{
    public partial class Pts_GiftRepository : RepositoryBase<PtsGift>, IPts_GiftRepository
    {
        public Pts_GiftRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IPts_GiftRepository Instance
        {
            get { return AutofacContainerModule.GetService<IPts_GiftRepository>(); }
        }
    }
}
