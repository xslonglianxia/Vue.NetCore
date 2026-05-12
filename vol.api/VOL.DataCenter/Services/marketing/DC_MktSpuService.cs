using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktSpuService : ServiceBase<DC_MktSpu, IDC_MktSpuRepository>
        , IDC_MktSpuService, IDependency
    {
        public static IDC_MktSpuService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktSpuService>(); } }
        }
    }
}
