using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktBannerService : ServiceBase<DC_MktBanner, IDC_MktBannerRepository>
        , IDC_MktBannerService, IDependency
    {
        public static IDC_MktBannerService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktBannerService>(); } }
        }
    }
}
