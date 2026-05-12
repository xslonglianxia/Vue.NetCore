using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktPerformanceStatisticService : ServiceBase<DC_MktPerformanceStatistic, IDC_MktPerformanceStatisticRepository>
        , IDC_MktPerformanceStatisticService, IDependency
    {
        public static IDC_MktPerformanceStatisticService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktPerformanceStatisticService>(); } }
        }
    }
}
