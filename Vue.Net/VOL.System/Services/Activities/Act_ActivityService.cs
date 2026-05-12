using VOL.System.IRepositories.Activities;
using VOL.System.IServices.Activities;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Activities;

namespace VOL.System.Services.Activities
{
    public partial class Act_ActivityService : ServiceBase<ActActivity, IAct_ActivityRepository>, IAct_ActivityService, IDependency
    {
        public Act_ActivityService(IAct_ActivityRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IAct_ActivityService Instance
        {
           get { return AutofacContainerModule.GetService<IAct_ActivityService>(); }
        }
    }
}
