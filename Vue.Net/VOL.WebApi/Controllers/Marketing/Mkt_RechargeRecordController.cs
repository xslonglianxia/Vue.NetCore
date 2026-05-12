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
    [Route("api/Mkt_RechargeRecord")]
    [PermissionTable(Name = "MktRechargeRecord")]
    public partial class Mkt_RechargeRecordController : ApiBaseController<IMkt_RechargeRecordService>
    {
        public Mkt_RechargeRecordController(IMkt_RechargeRecordService service)
        : base("Marketing","Marketing","MktRechargeRecord", service)
        {
        }
    }
}
