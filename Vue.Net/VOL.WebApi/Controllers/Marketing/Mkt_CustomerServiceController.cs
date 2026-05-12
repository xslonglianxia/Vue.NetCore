using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Marketing;
using VOL.System.IServices.Marketing;

namespace VOL.System.Controllers
{
    [Route("api/Mkt_CustomerService")]
    [PermissionTable(Name = "MktCustomerService")]
    public partial class Mkt_CustomerServiceController : ApiBaseController<IMkt_CustomerServiceService>
    {
        public Mkt_CustomerServiceController(IMkt_CustomerServiceService service)
        : base("Marketing","Marketing","MktCustomerService", service)
        {
        }
    }
}
