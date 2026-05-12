using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.DataCenter.IRepositories
{
    public partial interface IDC_SysOrgRepository : IDependency,IRepository<DC_SysOrg>
    {
    }
}
