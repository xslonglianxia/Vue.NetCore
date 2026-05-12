using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktNoticeService : ServiceBase<DC_MktNotice, IDC_MktNoticeRepository>
        , IDC_MktNoticeService, IDependency
    {
        public static IDC_MktNoticeService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktNoticeService>(); } }
        }
    }
}
