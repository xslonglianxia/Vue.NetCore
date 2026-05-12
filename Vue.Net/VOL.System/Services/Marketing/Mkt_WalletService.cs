using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_WalletService : ServiceBase<MktWallet, IMkt_WalletRepository>, IMkt_WalletService, IDependency
    {
        public Mkt_WalletService(IMkt_WalletRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_WalletService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_WalletService>(); }
        }
    }
}
