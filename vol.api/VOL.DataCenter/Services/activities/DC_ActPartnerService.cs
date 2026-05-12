using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_ActPartnerService : ServiceBase<DC_ActPartner, IDC_ActPartnerRepository>
        , IDC_ActPartnerService, IDependency
    {
        public static IDC_ActPartnerService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_ActPartnerService>(); } }
        }
    }
}
