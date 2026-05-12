using VOL.System.IRepositories.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Repositories.Activities
{
    public partial class Act_PrizeRepository : RepositoryBase<ActPrize>, IAct_PrizeRepository
    {
        public Act_PrizeRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IAct_PrizeRepository Instance
        {
            get { return AutofacContainerModule.GetService<IAct_PrizeRepository>(); }
        }
    }
}
