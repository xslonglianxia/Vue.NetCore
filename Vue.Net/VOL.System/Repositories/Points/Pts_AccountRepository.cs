using VOL.System.IRepositories.Points;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Repositories.Points
{
    public partial class Pts_AccountRepository : RepositoryBase<PtsAccount>, IPts_AccountRepository
    {
        public Pts_AccountRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IPts_AccountRepository Instance
        {
            get { return AutofacContainerModule.GetService<IPts_AccountRepository>(); }
        }
    }
}
