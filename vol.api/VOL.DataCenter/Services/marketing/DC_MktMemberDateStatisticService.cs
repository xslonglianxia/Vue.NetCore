using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktMemberDateStatisticService : ServiceBase<DC_MktMemberDateStatistic, IDC_MktMemberDateStatisticRepository>
        , IDC_MktMemberDateStatisticService, IDependency
    {
        public static IDC_MktMemberDateStatisticService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberDateStatisticService>(); } }
        }
    }
}
