using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_PtsAccountService : ServiceBase<DC_PtsAccount, IDC_PtsAccountRepository>
        , IDC_PtsAccountService, IDependency
    {
        public static IDC_PtsAccountService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsAccountService>(); } }
        }
    }
}
