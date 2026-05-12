using VOL.System.IRepositories.Points;
using VOL.System.IServices.Points;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Points;

namespace VOL.System.Services.Points
{
    public partial class Pts_FlowService : ServiceBase<PtsFlow, IPts_FlowRepository>, IPts_FlowService, IDependency
    {
        public Pts_FlowService(IPts_FlowRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IPts_FlowService Instance
        {
           get { return AutofacContainerModule.GetService<IPts_FlowService>(); }
        }
    }
}
