using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_PtsGiftOrderService : ServiceBase<DC_PtsGiftOrder, IDC_PtsGiftOrderRepository>
        , IDC_PtsGiftOrderService, IDependency
    {
        public static IDC_PtsGiftOrderService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsGiftOrderService>(); } }
        }
    }
}
