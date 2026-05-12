using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktMemberStatisticService : ServiceBase<DC_MktMemberStatistic, IDC_MktMemberStatisticRepository>
        , IDC_MktMemberStatisticService, IDependency
    {
        public static IDC_MktMemberStatisticService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberStatisticService>(); } }
        }
    }
}
