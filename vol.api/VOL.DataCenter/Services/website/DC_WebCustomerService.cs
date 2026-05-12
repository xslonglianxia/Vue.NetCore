using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_WebCustomerService : ServiceBase<DC_WebCustomer, IDC_WebCustomerRepository>
        , IDC_WebCustomerService, IDependency
    {
        public static IDC_WebCustomerService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_WebCustomerService>(); } }
        }
    }
}
