using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktStatisticService : ServiceBase<DC_MktStatistic, IDC_MktStatisticRepository>
        , IDC_MktStatisticService, IDependency
    {
        public static IDC_MktStatisticService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktStatisticService>(); } }
        }
    }
}
