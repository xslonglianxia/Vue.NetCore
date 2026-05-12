using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_YuebaoAccountService : ServiceBase<MktYuebaoAccount, IMkt_YuebaoAccountRepository>, IMkt_YuebaoAccountService, IDependency
    {
        public Mkt_YuebaoAccountService(IMkt_YuebaoAccountRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_YuebaoAccountService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_YuebaoAccountService>(); }
        }
    }
}
