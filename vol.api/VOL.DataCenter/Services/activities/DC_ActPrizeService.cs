using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_ActPrizeService : ServiceBase<DC_ActPrize, IDC_ActPrizeRepository>
        , IDC_ActPrizeService, IDependency
    {
        public static IDC_ActPrizeService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActPrizeService>(); } }
        }
    }
}
