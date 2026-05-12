using VOL.System.IRepositories.Points;
using VOL.System.IServices.Points;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Services.Points
{
    public partial class Pts_AccountService : ServiceBase<PtsAccount, IPts_AccountRepository>, IPts_AccountService, IDependency
    {
        public Pts_AccountService(IPts_AccountRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IPts_AccountService Instance
        {
           get { return AutofacContainerModule.GetService<IPts_AccountService>(); }
        }
    }
}
