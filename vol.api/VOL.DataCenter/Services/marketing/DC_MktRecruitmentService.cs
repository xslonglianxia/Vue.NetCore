using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktRecruitmentService : ServiceBase<DC_MktRecruitment, IDC_MktRecruitmentRepository>
        , IDC_MktRecruitmentService, IDependency
    {
        public static IDC_MktRecruitmentService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktRecruitmentService>(); } }
        }
    }
}
