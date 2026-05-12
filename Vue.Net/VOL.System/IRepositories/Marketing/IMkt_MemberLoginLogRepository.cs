using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels.Marketing;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.System.IRepositories.Marketing
{
    public partial interface IMkt_MemberLoginLogRepository : IDependency,IRepository<MktMemberLoginLog>
    {
    }
}
