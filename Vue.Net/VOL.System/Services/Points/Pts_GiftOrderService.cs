using VOL.System.IRepositories.Points;
using VOL.System.IServices.Points;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Services.Points
{
    public partial class Pts_GiftOrderService : ServiceBase<PtsGiftOrder, IPts_GiftOrderRepository>, IPts_GiftOrderService, IDependency
    {
        public Pts_GiftOrderService(IPts_GiftOrderRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IPts_GiftOrderService Instance
        {
           get { return AutofacContainerModule.GetService<IPts_GiftOrderService>(); }
        }
    }
}
