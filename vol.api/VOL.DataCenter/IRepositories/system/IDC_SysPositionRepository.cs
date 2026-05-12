using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.DataCenter.IRepositories
{
    public partial interface IDC_SysPositionRepository : IDependency,IRepository<DC_SysPosition>
    {
    }
}
