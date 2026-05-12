using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktBulletinService : ServiceBase<DC_MktBulletin, IDC_MktBulletinRepository>
        , IDC_MktBulletinService, IDependency
    {
        public static IDC_MktBulletinService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktBulletinService>(); } }
        }
    }
}
