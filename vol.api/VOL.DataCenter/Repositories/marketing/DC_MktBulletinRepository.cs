using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktBulletinRepository : RepositoryBase<DC_MktBulletin> , IDC_MktBulletinRepository
    {
        public DC_MktBulletinRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktBulletinRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktBulletinRepository>(); } }
        }
    }
}
