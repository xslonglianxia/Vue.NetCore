using VOL.System.IRepositories.Points;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Repositories.Points
{
    public partial class Pts_FlowRepository : RepositoryBase<PtsFlow>, IPts_FlowRepository
    {
        public Pts_FlowRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IPts_FlowRepository Instance
        {
            get { return AutofacContainerModule.GetService<IPts_FlowRepository>(); }
        }
    }
}
