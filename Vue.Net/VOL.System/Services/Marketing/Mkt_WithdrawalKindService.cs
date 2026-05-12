using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_WithdrawalKindService : ServiceBase<MktWithdrawalKind, IMkt_WithdrawalKindRepository>, IMkt_WithdrawalKindService, IDependency
    {
        public Mkt_WithdrawalKindService(IMkt_WithdrawalKindRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_WithdrawalKindService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_WithdrawalKindService>(); }
        }
    }
}
