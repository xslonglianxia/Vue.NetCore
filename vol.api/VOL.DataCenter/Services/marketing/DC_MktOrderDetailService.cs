using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktOrderDetailService : ServiceBase<DC_MktOrderDetail, IDC_MktOrderDetailRepository>
        , IDC_MktOrderDetailService, IDependency
    {
        public static IDC_MktOrderDetailService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktOrderDetailService>(); } }
        }
    }
}
