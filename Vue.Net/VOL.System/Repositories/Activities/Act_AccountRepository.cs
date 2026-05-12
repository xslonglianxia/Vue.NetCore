using VOL.System.IRepositories.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Repositories.Activities
{
    public partial class Act_AccountRepository : RepositoryBase<ActAccount>, IAct_AccountRepository
    {
        public Act_AccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IAct_AccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IAct_AccountRepository>(); }
        }
    }
}
