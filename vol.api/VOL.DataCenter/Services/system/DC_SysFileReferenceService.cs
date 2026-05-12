using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_SysFileReferenceService : ServiceBase<DC_SysFileReference, IDC_SysFileReferenceRepository>
        , IDC_SysFileReferenceService, IDependency
    {
        public static IDC_SysFileReferenceService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_SysFileReferenceService>(); } }
        }
    }
}
