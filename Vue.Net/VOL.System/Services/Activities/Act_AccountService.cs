using VOL.System.IRepositories.Activities;
using VOL.System.IServices.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Services.Activities
{
    public partial class Act_AccountService : ServiceBase<ActAccount, IAct_AccountRepository>, IAct_AccountService, IDependency
    {
        public Act_AccountService(IAct_AccountRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IAct_AccountService Instance
        {
           get { return AutofacContainerModule.GetService<IAct_AccountService>(); }
        }
    }
}
