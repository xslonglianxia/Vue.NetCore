using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_PtsFlowService : ServiceBase<DC_PtsFlow, IDC_PtsFlowRepository>
        , IDC_PtsFlowService, IDependency
    {
        public static IDC_PtsFlowService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_PtsFlowService>(); } }
        }
    }
}
