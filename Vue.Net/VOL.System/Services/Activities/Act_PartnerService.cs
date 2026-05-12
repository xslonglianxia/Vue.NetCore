using VOL.System.IRepositories.Activities;
using VOL.System.IServices.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Services.Activities
{
    public partial class Act_PartnerService : ServiceBase<ActPartner, IAct_PartnerRepository>, IAct_PartnerService, IDependency
    {
        public Act_PartnerService(IAct_PartnerRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IAct_PartnerService Instance
        {
           get { return AutofacContainerModule.GetService<IAct_PartnerService>(); }
        }
    }
}
