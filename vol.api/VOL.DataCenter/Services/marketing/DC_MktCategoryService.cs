using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktCategoryService : ServiceBase<DC_MktCategory, IDC_MktCategoryRepository>
        , IDC_MktCategoryService, IDependency
    {
        public static IDC_MktCategoryService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktCategoryService>(); } }
        }
    }
}
