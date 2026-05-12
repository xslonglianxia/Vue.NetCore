using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels.Points;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.System.IRepositories.Points
{
    public partial interface IPts_GiftOrderRepository : IDependency,IRepository<PtsGiftOrder>
    {
    }
}
