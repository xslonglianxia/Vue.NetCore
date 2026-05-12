using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_PtsGiftService : ServiceBase<DC_PtsGift, IDC_PtsGiftRepository>
        , IDC_PtsGiftService, IDependency
    {
        public static IDC_PtsGiftService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsGiftService>(); } }
        }
    }
}
