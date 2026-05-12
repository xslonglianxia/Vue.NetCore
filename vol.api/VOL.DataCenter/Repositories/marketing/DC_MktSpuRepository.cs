using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktSpuRepository : RepositoryBase<DC_MktSpu> , IDC_MktSpuRepository
    {
        public DC_MktSpuRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktSpuRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktSpuRepository>(); } }
        }
    }
}
