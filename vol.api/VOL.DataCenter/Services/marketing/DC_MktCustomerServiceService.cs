using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktCustomerServiceService : ServiceBase<DC_MktCustomerService, IDC_MktCustomerServiceRepository>
        , IDC_MktCustomerServiceService, IDependency
    {
        public static IDC_MktCustomerServiceService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktCustomerServiceService>(); } }
        }
    }
}
