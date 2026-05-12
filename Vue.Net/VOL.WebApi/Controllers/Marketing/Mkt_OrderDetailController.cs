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
    [Route("api/Mkt_OrderDetail")]
    [PermissionTable(Name = "MktOrderDetail")]
    public partial class Mkt_OrderDetailController : ApiBaseController<IMkt_OrderDetailService>
    {
        public Mkt_OrderDetailController(IMkt_OrderDetailService service)
        : base("Marketing","Marketing","MktOrderDetail", service)
        {
        }
    }
}
