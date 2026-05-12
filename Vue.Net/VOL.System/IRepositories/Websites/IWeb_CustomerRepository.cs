using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels.Websites;
using VOL.Core.Extensions.AutofacManager;

namespace VOL.System.IRepositories.Websites
{
    public partial interface IWeb_CustomerRepository : IDependency,IRepository<WebCustomer>
    {
    }
}
