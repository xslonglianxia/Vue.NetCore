using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktYuebaoAccountService : ServiceBase<DC_MktYuebaoAccount, IDC_MktYuebaoAccountRepository>
        , IDC_MktYuebaoAccountService, IDependency
    {
        public static IDC_MktYuebaoAccountService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktYuebaoAccountService>(); } }
        }
    }
}
