using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels.System;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.System.IRepositories.System
{
    public partial interface ISys_UserLoginLogRepository : IDependency,IRepository<Sys_UserLoginLog>
    {
    }
}
