using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_ActActivityService : ServiceBase<DC_ActActivity, IDC_ActActivityRepository>
        , IDC_ActActivityService, IDependency
    {
        public static IDC_ActActivityService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActActivityService>(); } }
        }
    }
}
