using VOL.System.IRepositories.Points;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Repositories.Points
{
    public partial class Pts_GiftOrderRepository : RepositoryBase<PtsGiftOrder>, IPts_GiftOrderRepository
    {
        public Pts_GiftOrderRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IPts_GiftOrderRepository Instance
        {
            get { return AutofacContainerModule.GetService<IPts_GiftOrderRepository>(); }
        }
    }
}
