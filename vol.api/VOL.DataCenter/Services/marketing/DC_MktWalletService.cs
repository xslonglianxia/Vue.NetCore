using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktWalletService : ServiceBase<DC_MktWallet, IDC_MktWalletRepository>
        , IDC_MktWalletService, IDependency
    {
        public static IDC_MktWalletService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktWalletService>(); } }
        }
    }
}
