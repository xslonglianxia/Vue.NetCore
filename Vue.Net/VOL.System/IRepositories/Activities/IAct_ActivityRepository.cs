using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels.Activities;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.System.IRepositories.Activities
{
    public partial interface IAct_ActivityRepository : IDependency,IRepository<ActActivity>
    {
    }
}
