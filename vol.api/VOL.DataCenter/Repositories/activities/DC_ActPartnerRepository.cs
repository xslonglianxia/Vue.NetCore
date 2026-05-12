using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_ActPartnerRepository : RepositoryBase<DC_ActPartner> , IDC_ActPartnerRepository
    {
        public DC_ActPartnerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_ActPartnerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActPartnerRepository>(); } }
        }
    }
}
