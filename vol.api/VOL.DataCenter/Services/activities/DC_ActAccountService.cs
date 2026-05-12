using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_ActAccountService : ServiceBase<DC_ActAccount, IDC_ActAccountRepository>
        , IDC_ActAccountService, IDependency
    {
        public static IDC_ActAccountService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActAccountService>(); } }
        }
    }
}
