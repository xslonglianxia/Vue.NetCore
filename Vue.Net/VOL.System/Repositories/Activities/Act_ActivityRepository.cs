using VOL.System.IRepositories.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Repositories.Activities
{
    public partial class Act_ActivityRepository : RepositoryBase<ActActivity>, IAct_ActivityRepository
    {
        public Act_ActivityRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IAct_ActivityRepository Instance
        {
            get { return AutofacContainerModule.GetService<IAct_ActivityRepository>(); }
        }
    }
}
