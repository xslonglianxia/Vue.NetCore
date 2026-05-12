using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktSettingService : ServiceBase<DC_MktSetting, IDC_MktSettingRepository>
        , IDC_MktSettingService, IDependency
    {
        public static IDC_MktSettingService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktSettingService>(); } }
        }
    }
}
