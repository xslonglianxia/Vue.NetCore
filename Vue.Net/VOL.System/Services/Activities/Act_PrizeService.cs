using VOL.System.IRepositories.Activities;
using VOL.System.IServices.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Services.Activities
{
    public partial class Act_PrizeService : ServiceBase<ActPrize, IAct_PrizeRepository>, IAct_PrizeService, IDependency
    {
        public Act_PrizeService(IAct_PrizeRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IAct_PrizeService Instance
        {
           get { return AutofacContainerModule.GetService<IAct_PrizeService>(); }
        }
    }
}
