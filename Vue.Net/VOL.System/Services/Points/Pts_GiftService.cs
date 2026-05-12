using VOL.System.IRepositories.Points;
using VOL.System.IServices.Points;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Services.Points
{
    public partial class Pts_GiftService : ServiceBase<PtsGift, IPts_GiftRepository>, IPts_GiftService, IDependency
    {
        public Pts_GiftService(IPts_GiftRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IPts_GiftService Instance
        {
           get { return AutofacContainerModule.GetService<IPts_GiftService>(); }
        }
    }
}
