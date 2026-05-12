using VOL.System.IRepositories.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Repositories.Activities
{
    public partial class Act_PartnerRepository : RepositoryBase<ActPartner>, IAct_PartnerRepository
    {
        public Act_PartnerRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IAct_PartnerRepository Instance
        {
            get { return AutofacContainerModule.GetService<IAct_PartnerRepository>(); }
        }
    }
}
