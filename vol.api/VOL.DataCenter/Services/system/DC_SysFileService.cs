using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysFileService : ServiceBase<DC_SysFile, IDC_SysFileRepository>
        , IDC_SysFileService, IDependency
    {
        public static IDC_SysFileService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysFileService>(); } }
        }
    }
}
